using flexi.Entities;
using TechTalk.DatabaseAccessor.Services;

namespace flexi.Repository;
public class VenueRepository : IVenueRepository
{
    private readonly IDatabaseAccessor _databaseAccessor;
    private const string tableName = "venue";
    private const string InsertVenueSql = $@"
        INSERT INTO {tableName} (
          VenueName, 
          VenueCapacity
        ) 
        VALUES (
          @VenueName, 
          @VenueCapacity
        );
        SELECT LAST_INSERT_ID();";

    public VenueRepository(IDatabaseAccessor databaseAccessor)
    {
        _databaseAccessor = databaseAccessor;
    }

    public async Task<IEnumerable<Venue>> GetAllVenues()
    {
        string sql = $"SELECT * FROM {tableName}";
        return await _databaseAccessor.QueryAsync<Venue>(sql);
    }

    public async Task<Venue> AddVenue(Venue venueInfo)
    {
        int newId = await _databaseAccessor
          .InsertScalarAsync<int>(InsertVenueSql, venueInfo);
          
        return venueInfo with { VenueId = newId };
    }
}