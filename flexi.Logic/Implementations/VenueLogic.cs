using flexi.Entities;
using flexi.Repository;

namespace flexi.Logic;

public class VenueLogic : IVenueLogic
{
    private readonly IVenueRepository _venueRepo;

    public VenueLogic(IVenueRepository venueRepository)
    {
        _venueRepo = venueRepository;
    }

    public async Task<IEnumerable<Venue>> GetAllVenues()
    {
        return await _venueRepo.GetAllVenues();
    }

    public async Task<Venue> AddVenue(Venue venueInfo)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(
          venueInfo.VenueName, nameof(venueInfo.VenueName));
        
        if (venueInfo.VenueCapacity <= 0)
        {
            throw new ArgumentException(
              "Venue capacity must be greater than zero.", 
              nameof(venueInfo.VenueCapacity));
        }

        return await _venueRepo.AddVenue(venueInfo);
    }
}
