namespace MedCompatibility.Configuration;

public class ConnectionOptions
{
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; } = 3306;
    public string Name { get; set; } = string.Empty;
    public string User { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class DatabaseSettings
{
    public ConnectionOptions Cloud { get; set; } = new();
    public ConnectionOptions Local { get; set; } = new();
}