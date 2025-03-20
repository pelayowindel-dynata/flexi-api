using flexi.Entities;

namespace flexi.Logic;

public interface IVenueLogic
{
    public Task<IEnumerable<Venue>> GetAllVenues();
    public Task<Venue> AddVenue(Venue venueInfo);
}
