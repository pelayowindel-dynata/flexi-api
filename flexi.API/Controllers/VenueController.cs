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
    public async Task<IActionResult> AddVenue(Venue venue)
    {
        if (venue == null)
        {
            return BadRequest("Venue cannot be null.");
        }

        try 
        {
            var addedVenue = await _venueLogic.AddVenue(venue);
            return Ok(addedVenue);
        } 
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
