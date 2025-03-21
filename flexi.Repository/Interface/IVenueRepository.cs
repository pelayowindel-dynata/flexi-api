using flexi.Entities;

namespace flexi.Repository;
public interface IVenueRepository
{
    Task<IEnumerable<Venue>> GetAllVenues();
    Task<Venue> AddVenue(Venue venueInfo);
}
