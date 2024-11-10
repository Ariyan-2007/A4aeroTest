namespace A4aeroTest.Models
{
    public class TBOFlightSearchRequest
    {
        public required string IPAddress { get; set; }
        public required string TokenId { get; set; }
        public required string TrackingId { get; set; }
        public int JourneyType { get; set; }
        public int AdultCount { get; set; }
        public List<Segment> Segment { get; set; }

        public TBOFlightSearchRequest()
        {
            Segment = new List<Segment>(); 
        }
    }

    public class Segment
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime PreferredDepartureTime { get; set; }
        public DateTime PreferredArrivalTime { get; set; }
    }
}
