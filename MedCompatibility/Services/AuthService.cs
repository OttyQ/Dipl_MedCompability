using MedCompatibility.Models;
using Microsoft.EntityFrameworkCore;
using BCrypt.Net;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.Services;

public class AuthService : IAuthService
{
    private readonly IDbContextFactory<DrugContext> _contextFactory;
    public AuthService(IDbContextFactory<DrugContext> contextFactory)
    {
        _contextFactory = contextFactory;
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
}
