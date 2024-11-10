namespace A4aeroTest.Models
{
    public class AuthResponse
    {
        public required string IPAddress { get; set; }
        public required string TokenId { get; set; }
        public required string TrackingId { get; set; }
    }
}
