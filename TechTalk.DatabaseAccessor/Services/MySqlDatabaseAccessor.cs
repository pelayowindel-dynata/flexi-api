using Dapper;
using MySqlConnector;
using TechTalk.DatabaseAccessor.Models;

namespace TechTalk.DatabaseAccessor.Services;

public class MySqlDatabaseAccessor : IDatabaseAccessor
{
  private DatabaseCredential _databaseCredential;

  public MySqlDatabaseAccessor(DatabaseCredential databaseCredential)
  {
    _databaseCredential = databaseCredential;
  }

  public async Task<int> InsertAsync(string sql, object parameters)
  {
    return await ExecuteAsync(sql, parameters);
  }

  public async Task<T> InsertScalarAsync<T>(string sql, object parameters)
  {
    return await ExecuteScalarAsync<T>(sql, parameters);
  }

  public async Task<int> ExecuteAsync(string sql)
  {
    var connectionString = GetConnectionString();

    await using var dbConnection = new MySqlConnection(connectionString);
    return await dbConnection.ExecuteAsync(sql);
  }

  public async Task<int> ExecuteAsync(string sql, object parameters)
  {
    var connectionString = GetConnectionString();

    await using var dbConnection = new MySqlConnection(connectionString);
    return await dbConnection.ExecuteAsync(sql, parameters);
  }

  public async Task<T> ExecuteScalarAsync<T>(string sql)
  {
    var connectionString = GetConnectionString();

    await using var dbConnection = new MySqlConnection(connectionString);
    return await dbConnection.ExecuteScalarAsync<T>(sql) ?? default!;
  }

  public async Task<T> ExecuteScalarAsync<T>(string sql, object parameters)
  {
    var connectionString = GetConnectionString();

    await using var dbConnection = new MySqlConnection(connectionString);
    return await dbConnection.ExecuteScalarAsync<T>(sql, parameters) ?? default!;
  }

  public async Task<IEnumerable<T>> QueryAsync<T>(string sql)
  {
    var connectionString = GetConnectionString();

    await using var dbConnection = new MySqlConnection(connectionString);
    return await dbConnection.QueryAsync<T>(sql);
  }

  public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters)
  {
    var connectionString = GetConnectionString();

    await using var dbConnection = new MySqlConnection(connectionString);
    return await dbConnection.QueryAsync<T>(sql, parameters);
  }

  public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object parameters)
  {
    var connectionString = GetConnectionString();

    await using var dbConnection = new MySqlConnection(connectionString);
    return await dbConnection.QueryFirstOrDefaultAsync<T>(sql, parameters) ?? default!;
  }

  public async Task<T> SingleAsync<T>(string sql, object parameters)
  {
    var connectionString = GetConnectionString();

    await using var dbConnection = new MySqlConnection(connectionString);
    return await dbConnection.QuerySingleAsync<T>(sql, parameters);
  }

  private string GetConnectionString()
  {
    return _databaseCredential.GetConnectionString();
  }
}