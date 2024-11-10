using A4aeroTest.Models;

namespace A4aeroTest.Services.Interfaces
{
    public interface IFlightSearchService
    {

        Task<List<FlightSearchResponse>> SearchFlightsAsync(FlightSearchRequest req); 
    }
}
