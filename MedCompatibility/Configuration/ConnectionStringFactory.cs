using MySqlConnector;

namespace MedCompatibility.Configuration;
using Microsoft.Extensions.Options;

public interface IConnectionStringFactory
{
    string CreateMySqlConnectionString();
}


public class ConnectionStringFactory : IConnectionStringFactory
{
    private readonly DatabaseSettings _settings;
    
    // Флаг: какую базу используем сейчас. По умолчанию - Облако.
    public static bool UseLocalDatabase { get; set; } = false; 

    public ConnectionStringFactory(IOptions<DatabaseSettings> settings)
    {
        _settings = settings.Value;
    }

    public string CreateMySqlConnectionString()
    {
        // Выбираем конфиг в зависимости от флага
        var config = UseLocalDatabase ? _settings.Local : _settings.Cloud;

        var builder = new MySqlConnectionStringBuilder
        {
            Server = config.Host,
            Port = (uint)config.Port,
            UserID = config.User,
            Password = config.Password,
            Database = config.Name,
            SslMode = MySqlSslMode.Required,
            Pooling = true,
            ConnectionReset = true,
            // Для локальной можно поменьше, для облака - побольше
            ConnectionTimeout = UseLocalDatabase ? 10u : 20u 
        };

        return builder.ConnectionString;
    }
}
