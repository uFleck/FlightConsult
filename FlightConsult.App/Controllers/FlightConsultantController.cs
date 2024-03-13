using FlightConsult.Core.Models;
using FlightConsult.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightConsult.App.Controllers;


[ApiController]
[AllowAnonymous]
[Route("api/v1/[controller]")]
public class FlightConsultantController(IFlightConsultantService flightConsultantService) : ControllerBase
{
    [HttpPost("GetAvaliableFlights")]
    public async Task<ActionResult<IEnumerable<Flight>>> GetAvaliableFlights([FromBody] FlightSearch flightSearch)
    {
        if (flightSearch.Date < DateTime.UtcNow.Date)
            return BadRequest("Date provided was invalid");

        var flights = await flightConsultantService.GetAvaliableFlights(flightSearch);

        return Ok(flights);
    }
}
