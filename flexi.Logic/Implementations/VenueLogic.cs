using flexi.Common.DTO;
using flexi.Common.Model;
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

    public async Task<Venue> AddVenue(CreateVenueDto createVenueDto)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(
          createVenueDto.VenueName, nameof(createVenueDto.VenueName));
        
        if (createVenueDto.VenueCapacity <= 0)
        {
            throw new ArgumentException(
              "Venue capacity must be greater than zero.", 
              nameof(createVenueDto.VenueCapacity));
        }

        CreateVenue createVenue = new CreateVenue{
          VenueName = createVenueDto.VenueName,
          VenueCapacity = createVenueDto.VenueCapacity
        };

        return await _venueRepo.AddVenue(createVenue);
    }
}
