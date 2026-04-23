namespace MedCompatibility.Models;

public partial class user
{
    public string FullName => string.IsNullOrWhiteSpace(MiddleName) 
        ? $"{LastName} {FirstName}" 
        : $"{LastName} {FirstName} {MiddleName}";
}
