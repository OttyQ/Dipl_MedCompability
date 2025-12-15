using MedCompatibility.Models;
using MedCompatibility.Services.Interfaces;

namespace MedCompatibility.Services;

public class UserSessionService : IUserSessionService
{
    public user? CurrentUser { get; private set; }

    public bool IsAuthenticated => CurrentUser != null;
    
    // Если пользователь null, считаем его гостем (если ваша логика подразумевает явный вход как Гость, можно добавить флаг)
    public bool IsGuest => CurrentUser == null;

    public void StartSession(user user)
    {
        CurrentUser = user;
    }

    public void EndSession()
    {
        CurrentUser = null;
    }
}