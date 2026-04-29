using MedCompatibility.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.Services;

public class AuthService : IAuthService
{
    private readonly IDbContextFactory<DrugContext> _contextFactory;
    private readonly IAppLogService _appLogService;

    public AuthService(IDbContextFactory<DrugContext> contextFactory, IAppLogService appLogService)
    {
        _contextFactory = contextFactory;
        _appLogService = appLogService;
    }

    public async Task<user?> LoginAsync(string login, string password)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var user = await context.users
            .AsNoTracking()
            .Include(u => u.Role)
            .FirstOrDefaultAsync(u => u.Login == login);
        if (user == null) return null;
        bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
        if (!isPasswordValid) return null;

        await _appLogService.LogAsync("Info", "Auth", "Успешный вход в систему", user.UserId);
        return user;
    }

    public async Task<string> RegisterUserAsync(string login, string password, string firstName, string lastName, string middleName, string roleName)
    {   
        try {
            using var context = await _contextFactory.CreateDbContextAsync();
            var exists = await context.users.AnyAsync(u => u.Login == login);
            if (exists) return "Пользователь с таким логином уже существует";
            var role = await context.roles.FirstOrDefaultAsync(r => r.Name.ToLower() == roleName.ToLower());
            if (role == null) return $"Ошибка: роль '{roleName}' не найдена";
            bool isApproved = (roleName.ToLower() != "doctor" && roleName.ToLower() != "врач");
            var newUser = new user 
            {
                Login = login,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(password),
                FirstName = firstName,
                LastName = lastName,
                MiddleName = middleName,
                RoleId = role.RoleId,
                IsApproved = isApproved,
                CreatedAt = DateTime.Now
            };
            context.users.Add(newUser);
            await context.SaveChangesAsync();
            return null;
        } catch (Exception ex) {
            return $"Ошибка базы данных: {ex.Message}";
        }
    }

    public async Task<user?> LoginWithGoogleAsync(string email, string sub, string firstName, string lastName, string? roleName = null)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        
        var externalLogin = await context.userexternallogins
            .Include(e => e.User)
            .Include(e => e.User.Role)
            .FirstOrDefaultAsync(e => e.ProviderName == "Google" && e.ProviderKey == sub);

        if (externalLogin != null)
        {
            if (externalLogin.User.IsDeleted) return null;
            await _appLogService.LogAsync("Info", "Auth", "Успешный вход через Google", externalLogin.User.UserId);
            return externalLogin.User;
        }

        var user = await context.users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Login == email);
        if (user != null)
        {
            if (user.IsDeleted) return null;

            context.userexternallogins.Add(new userexternallogin
            {
                UserId = user.UserId,
                ProviderName = "Google",
                ProviderKey = sub
            });

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(Guid.NewGuid().ToString());
            
            await context.SaveChangesAsync();
            await _appLogService.LogAsync("Info", "Auth", "Миграция OAuth и вход через Google", user.UserId);
            return user;
        }

        if (roleName == null) return null;

        var role = await context.roles.FirstOrDefaultAsync(r => r.Name.ToLower() == roleName.ToLower());
        if (role == null) throw new Exception($"Role '{roleName}' not found");

        var newUser = new user
        {
            Login = email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(Guid.NewGuid().ToString()),
            FirstName = firstName,
            LastName = lastName,
            MiddleName = "",
            RoleId = role.RoleId,
            IsApproved = true,
            CreatedAt = DateTime.Now
        };

        context.users.Add(newUser);
        await context.SaveChangesAsync();

        context.userexternallogins.Add(new userexternallogin
        {
            UserId = newUser.UserId,
            ProviderName = "Google",
            ProviderKey = sub
        });

        await context.SaveChangesAsync();
        
        newUser.Role = role;
        await _appLogService.LogAsync("Info", "Auth", "Регистрация и вход через Google", newUser.UserId);
        return newUser;
    }

    public async Task<string?> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
    {
        using var context = await _contextFactory.CreateDbContextAsync();
        var user = await context.users.FirstOrDefaultAsync(u => u.UserId == userId);
        
        if (user == null) 
            return "Пользователь не найден";

        if (!BCrypt.Net.BCrypt.Verify(oldPassword, user.PasswordHash))
            return "Неверный текущий пароль";

        if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
            return "Новый пароль должен содержать минимум 6 символов";

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
        await context.SaveChangesAsync();

        await _appLogService.LogAsync("Info", "Auth", "Смена пароля", user.UserId);

        return null; // Успех
    }
}
