using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCompatibility.Services;

public class UserService : IUserService
{
    private readonly IDbContextFactory<DrugContext> _contextFactory;

    public UserService(IDbContextFactory<DrugContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<user>> GetAllUsersAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        
        return await context.users // с маленькой u
            .AsNoTracking() // Важно для read-only списков!
            .Include(u => u.Role)
            .OrderByDescending(u => u.CreatedAt)
            .ToListAsync();
    }

    public async Task ToggleUserStatusAsync(int userId, bool isApproved)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        
        var user = await context.users.FindAsync(userId);
        if (user != null)
        {
            user.IsApproved = isApproved;
            await context.SaveChangesAsync();
        }
    }
    public async Task<int> GetPatientsCountAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.users.AsNoTracking()
            .Where(u => u.Role.Name == "patient")
            .CountAsync();
    }

    public async Task<int> GetDoctorsCountAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        return await context.users.AsNoTracking()
            .Where(u => u.Role.Name == "doctor")
            .CountAsync();
    }
    
    public async Task<int> GetActiveDoctorsCountAsync()
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        return await context.users.AsNoTracking()
            .Where(u => u.Role.Name == "doctor" && u.IsApproved == true)
            .CountAsync();
    }
    
    public async Task<List<user>> GetUsersFilteredAsync(string? searchText, string? roleName, string? status)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var query = context.users
            .AsNoTracking()
            .Include(u => u.Role)
            .AsQueryable();

        // 1. Поиск по ФИО и Логину
        if (!string.IsNullOrWhiteSpace(searchText))
        {
            string s = searchText.Trim().ToLower();
            query = query.Where(u => 
                u.Login.ToLower().Contains(s) || 
                u.LastName.ToLower().Contains(s) ||
                u.FirstName.ToLower().Contains(s) ||
                (u.MiddleName != null && u.MiddleName.ToLower().Contains(s))
            );
        }

        // 2. Фильтр по роли
        if (!string.IsNullOrWhiteSpace(roleName) && roleName != "Все")
        {
            // Если в UI написано "Врачи", а в БД "doctor"
            string dbRole = roleName switch
            {
                "Врачи" => "doctor",
                "Пациенты" => "patient",
                "Админы" => "admin",
                _ => roleName.ToLower()
            };
            query = query.Where(u => u.Role.Name == dbRole);
        }

        // 3. Фильтр по статусу
        if (!string.IsNullOrWhiteSpace(status) && status != "Все")
        {
            bool isActive = (status == "Активные");
            query = query.Where(u => u.IsApproved == isActive);
        }

        return await query.OrderByDescending(u => u.CreatedAt).ToListAsync();
    }
    
    public async Task DeleteUserAsync(int userId)
    {
        try
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var user = await context.users.FindAsync(userId);

            if (user != null)
            {
                user.IsDeleted = true;

                // Генерируем короткий уникальный суффикс, чтобы влезло в 50 символов
                // Формат: DEL_Id_Login (обрезанный)

                string prefix = $"DEL_{user.UserId}_";
                string oldLogin = user.Login;

                // Если логин + префикс длиннее 50, обрезаем старый логин
                if (prefix.Length + oldLogin.Length > 50)
                {
                    oldLogin = oldLogin.Substring(0, 50 - prefix.Length);
                }

                user.Login = prefix + oldLogin;

                await context.SaveChangesAsync();
            }
        }catch (Exception ex) {
            // Поставь точку останова здесь или выведи в лог
            System.Diagnostics.Debug.WriteLine($"CRASH ERROR: {ex.Message}");
            if (ex.InnerException != null)
                System.Diagnostics.Debug.WriteLine($"INNER: {ex.InnerException.Message}");
            throw; // Пробросить дальше, чтобы UI показал Alert
        }
    }
    
    public async Task UpdateUserProfileAsync(int userId, string firstName, string lastName, string middleName)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var user = await context.users.FindAsync(userId);
    
        if (user == null) throw new Exception("Пользователь не найден");

        user.FirstName = firstName;
        user.LastName = lastName;
        user.MiddleName = middleName;
    
        // Важно: Логин и Роль здесь не меняем в целях безопасности
    
        context.users.Update(user);
        await context.SaveChangesAsync();
    }
    
    public async Task<List<user>> SearchPatientsAsync(string query)
    {
        // Используем уже существующую логику фильтрации, но фиксируем роль "Пациенты" и статус "Активные"
        // query - это строка поиска (Фамилия)
        return await GetUsersFilteredAsync(query, "Пациенты", "Активные");
    }
    

// 2. Добавить связь
    public async Task<List<user>> GetDoctorPatientsAsync(int doctorId)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        var patientIds = await context.doctor_patient
            .AsNoTracking()
            .Where(dp => dp.DoctorId == doctorId)
            .Select(dp => dp.PatientId)
            .ToListAsync();

        if (patientIds.Count == 0) return new List<user>();

        return await context.users
            .AsNoTracking()
            .Include(u => u.Role)
            .Where(u => patientIds.Contains(u.UserId))
            .OrderBy(u => u.LastName).ThenBy(u => u.FirstName)
            .ToListAsync();
    }

    public async Task AddPatientToDoctorListAsync(int doctorId, int patientId)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        bool exists = await context.doctor_patient
            .AnyAsync(dp => dp.DoctorId == doctorId && dp.PatientId == patientId);

        if (exists) return;

        context.doctor_patient.Add(new doctor_patient
        {
            DoctorId = doctorId,
            PatientId = patientId,
            AddedAt = DateTime.Now
        });

        await context.SaveChangesAsync();
    }

    public async Task<List<user>> SearchNewPatientsAsync(string query, int excludeDoctorId)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        var existing = await context.doctor_patient
            .AsNoTracking()
            .Where(dp => dp.DoctorId == excludeDoctorId)
            .Select(dp => dp.PatientId)
            .ToListAsync();

        string term = query.Trim().ToLower();

        return await context.users
            .AsNoTracking()
            .Include(u => u.Role)
            .Where(u => u.Role.Name == "patient" && (u.IsApproved ?? false))
            .Where(u => !existing.Contains(u.UserId))
            .Where(u =>
                u.LastName.ToLower().Contains(term) ||
                u.FirstName.ToLower().Contains(term) ||
                u.Login.ToLower().Contains(term))
            .OrderBy(u => u.LastName).ThenBy(u => u.FirstName)
            .ToListAsync();
    }

    public async Task RemovePatientFromDoctorListAsync(int doctorId, int patientId)
    {
        using var context = await _contextFactory.CreateDbContextAsync();

        var link = await context.doctor_patient
            .FirstOrDefaultAsync(dp => dp.DoctorId == doctorId && dp.PatientId == patientId);

        if (link != null)
        {
            context.doctor_patient.Remove(link);
            await context.SaveChangesAsync();
        }
    }

}