using MedCompatibility.Models;

namespace MedCompatibility.Services.Interfaces;

public interface IAuthService
{
    Task<user?> LoginAsync(string login, string password);
    Task<string> RegisterUserAsync(string login, string password, string firstName, string lastName, string middleName, string roleName);
}