namespace TechTalk.DatabaseAccessor.Services;

public interface IDatabaseAccessor
{
    Task<int> InsertAsync(string sql, object parameters);
    Task<T> InsertScalarAsync<T>(string sql, object parameters);
    Task<int> ExecuteAsync(string sql);
    Task<int> ExecuteAsync(string sql, object parameters);
    Task<T> ExecuteScalarAsync<T>(string sql);
    Task<T> ExecuteScalarAsync<T>(string sql, object parameters);
    Task<IEnumerable<T>> QueryAsync<T>(string sql);
    Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters);
    Task<T> QueryFirstOrDefaultAsync<T>(string sql, object parameters);
    Task<T> SingleAsync<T>(string sql, object parameters);
}
