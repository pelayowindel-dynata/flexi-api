using flexi.Common.Model;
using flexi.Entities;

namespace flexi.Repository;
public interface IVenueRepository
{
    Task<IEnumerable<Venue>> GetAllVenues();
    Task<Venue> AddVenue(CreateVenue venueInfo);
}
