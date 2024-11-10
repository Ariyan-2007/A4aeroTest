namespace A4aeroTest.Models
{
    public class FlightSearchRequest
    {
        public required string Origin    { get; set; }
        public required string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime? ReturnDate     { get; set; }
        public bool IsRoundTrip => ReturnDate.HasValue;

    }
}
