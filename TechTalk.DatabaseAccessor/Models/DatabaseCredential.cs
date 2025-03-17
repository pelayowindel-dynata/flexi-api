using TechTalk.DatabaseAccessor.Exceptions;

namespace TechTalk.DatabaseAccessor.Models;

public class DatabaseCredential
{
  public string Database { get; set; } = string.Empty;
  public string Host { get; set; } = string.Empty;
  public int Port { get; set; }
  public string Username { get; set; } = string.Empty;
  public string Password { get; set; } = string.Empty;
  public bool AllowUserVariables { get; set; } = true;

  public void Validate()
  {
    if (string.IsNullOrWhiteSpace(Database))
    {
      throw new ArgumentNullException(nameof(Database));
    }

    if (string.IsNullOrWhiteSpace(Host))
    {
      ThrowException(nameof(Host), Database);
    }

    if (Port <= 0)
    {
      ThrowException(nameof(Port), Database);
    }

    if (string.IsNullOrWhiteSpace(Username))
    {
      ThrowException(nameof(Username), Database);
    }
  }

  public string GetConnectionString()
  {
    return $"Server={Host};Port={Port};Uid={Username};Pwd={Password};" +
           $"Database={Database};";
  }

  private static void ThrowException(string message, string database)
  {
    var databaseException = new DatabaseException(message);
    databaseException.Data.Add("Database", database);

    throw databaseException;
  }
}
