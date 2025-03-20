using flexi.Entities;

namespace flexi.Repository;
public interface IVenueRepository
{
    public Task<IEnumerable<Venue>> GetAllVenues();
    public Task<Venue> AddVenue(Venue venueInfo);
}
