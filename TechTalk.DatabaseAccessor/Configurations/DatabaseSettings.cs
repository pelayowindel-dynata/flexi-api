using TechTalk.DatabaseAccessor.Models;

namespace TechTalk.DatabaseAccessor.Configuration;

public class DatabaseSettings
{
  public string GetConnectionString(DatabaseCredential credential)
  {
    ArgumentNullException.ThrowIfNull(credential);

    return $"Server={credential.Host};Port={credential.Port};Uid={credential.Username};Pwd={credential.Password};" +
           $"Database={credential.Database};Allow User Variables={true};";
  }
}
