using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IUserSessionService
{
    user? CurrentUser { get; }
    bool IsAuthenticated { get; }
    bool IsGuest { get; }
    
    Task StartSessionAsync(user user);
    void EndSession();
    Task<bool> RestoreSessionAsync();
}