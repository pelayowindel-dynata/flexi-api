using Dapper;
using flexi.Entities;
using TechTalk.DatabaseAccessor.Services;

namespace flexi.Repository
{
    public class VenueRepository : IVenueRepository
    {
        private readonly IDatabaseAccessor _databaseAccessor;

        private const string tableName = "venue";

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
            string sql = $@"
            INSERT INTO {tableName} (VenueName, VenueCapacity) 
            VALUES (@VenueName, @VenueCapacity);
            SELECT LAST_INSERT_ID();"; 

            int newId = await _databaseAccessor.InsertScalarAsync<int>(sql, venueInfo);
            venueInfo.VenueId = newId;
            return venueInfo;
        }
    }
}
