﻿using A4aeroTest.Models;

namespace A4aeroTest.Services.Interfaces
{
    public interface IFlightSearchService
    {

        Task<dynamic> SearchFlightsAsync(FlightSearchRequest req); 
    }
}
