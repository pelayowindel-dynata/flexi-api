using flexi.Common.DTO;
using flexi.Entities;

namespace flexi.Logic;

public interface IVenueLogic
{
    Task<IEnumerable<Venue>> GetAllVenues();
    Task<Venue> AddVenue(CreateVenueDto venueInfo);
}
