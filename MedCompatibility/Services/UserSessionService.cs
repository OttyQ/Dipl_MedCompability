using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MedCompatibility.Services;

public class UserSessionService : IUserSessionService
{
    private readonly IDbContextFactory<DrugContext> _contextFactory;
    private const string UserIdKey = "auth_user_id";
    private const string UserRoleKey = "auth_user_role";

    public user? CurrentUser { get; private set; }

    public bool IsAuthenticated => CurrentUser != null;
    public bool IsGuest => CurrentUser == null;

    public UserSessionService(IDbContextFactory<DrugContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task StartSessionAsync(user user)
    {
        CurrentUser = user;
        
        await SecureStorage.Default.SetAsync(UserIdKey, user.UserId.ToString());
        await SecureStorage.Default.SetAsync(UserRoleKey, user.Role?.Name ?? "Patient");
    }

    public void EndSession()
    {
        CurrentUser = null;
        
        SecureStorage.Default.Remove(UserIdKey);
        SecureStorage.Default.Remove(UserRoleKey);
    }

    public async Task<bool> RestoreSessionAsync()
    {
        try
        {
            var userIdStr = await SecureStorage.Default.GetAsync(UserIdKey);
            if (string.IsNullOrEmpty(userIdStr))
            {
                return false;
            }

            if (!int.TryParse(userIdStr, out int userId))
            {
                return false;
            }

            using var context = await _contextFactory.CreateDbContextAsync();
            var user = await context.users
                .AsNoTracking()
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.UserId == userId);

            if (user != null)
            {
                if (user.IsApproved == false && (user.Role?.Name?.ToLower() == "doctor" || user.Role?.Name?.ToLower() == "patient"))
                {
                    EndSession();
                    return false;
                }

                CurrentUser = user;
                return true;
            }
            
            return false;
        }
        catch (Exception ex)
        {
            // Пробрасываем осмысленное исключение для обработки в UI
            throw new Exception("Ошибка при подключении к базе данных. Проверьте соединение с интернетом.", ex);
        }
    }
}