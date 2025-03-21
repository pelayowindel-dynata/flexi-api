using Microsoft.AspNetCore.Mvc;
using flexi.Logic;
using flexi.Entities;

namespace flexi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VenueController : ControllerBase
{
    private readonly IVenueLogic _venueLogic;

    public VenueController(IVenueLogic venueLogic)
    {
        _venueLogic = venueLogic;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVenues() 
    {
        var venues = await _venueLogic.GetAllVenues(); 
        return Ok(venues);
    }

    [HttpPost]
    public async Task<IActionResult> AddVenue([FromBody] Venue venue)
    {
        if (venue == null || string.IsNullOrWhiteSpace(venue.VenueName) || venue.VenueCapacity <= 0)
        {
            return BadRequest("Invalid venue data.");
        }

        var addedVenue = await _venueLogic.AddVenue(venue);
        return Ok(addedVenue);
    }
}
