using A4aeroTest.Models;
using A4aeroTest.Services.Implementations;
using A4aeroTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace A4aeroTest.Controllers
{
        [ApiController]
        [Route("/api/[controller]")]
    public class TBOFlightSearchController : ControllerBase
    {
        private readonly IFlightSearchService _searchService;

        public TBOFlightSearchController(IFlightSearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpPost("search")]
        public async Task<IActionResult> SearchFlights([FromBody] FlightSearchRequest request)
        {
            var result = await _searchService.SearchFlightsAsync(request);
            return Ok(result);
        }
    }
}
