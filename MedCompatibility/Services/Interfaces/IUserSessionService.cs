using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IUserSessionService
{
    user? CurrentUser { get; }
    bool IsAuthenticated { get; }
    bool IsGuest { get; }
    
    void StartSession(user user);
    void EndSession();
}