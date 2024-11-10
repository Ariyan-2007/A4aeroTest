using A4aeroTest.Models;
using A4aeroTest.Services.Interfaces;
using A4aeroTest.Utilities;

namespace A4aeroTest.Services.Implementations
{
    public class FlightSearchService : IFlightSearchService
    {
        private readonly IAuthService _authService;
        private readonly TBOApiClient _client;

        public FlightSearchService(IAuthService authService, TBOApiClient client)
        {
            _authService = authService;
            _client = client;
        }

        public async Task<List<FlightSearchResponse>> SearchFlightsAsync(FlightSearchRequest req) 
        {
            var auth = await _authService.GetAuthInfoAsync();


            var tboReq = FlightSearchToTBOFlightSearchMapper(req, auth);


            return await _client.SearchFlightsAsync(tboReq);

        }


        private TBOFlightSearchRequest FlightSearchToTBOFlightSearchMapper(FlightSearchRequest req, AuthResponse auth) 
        {


            var tboReq = new TBOFlightSearchRequest
            {
                IPAddress = auth.IPAddress,
                TokenId = auth.TokenId,
                TrackingId = auth.TrackingId,

                JourneyType = req.IsRoundTrip ? 2 : 1,

                AdultCount = 1,

                Segment = new List<Segment>()
            };

            var departureSegment = new Segment
            {
                Origin = req.Origin,
                Destination = req.Destination,
                PreferredArrivalTime = req.DepartureDate,
                PreferredDepartureTime = req.DepartureDate
            };

            tboReq.Segment.Add(departureSegment);

            if (req.IsRoundTrip)
            {
                var returnSegment = new Segment { Origin = req.Destination, Destination = req.Origin, PreferredDepartureTime = req.ReturnDate ?? req.DepartureDate, PreferredArrivalTime = req.ReturnDate ?? req.DepartureDate };

                tboReq.Segment.Add(returnSegment);
            }

            return tboReq;

        }
    }
}
