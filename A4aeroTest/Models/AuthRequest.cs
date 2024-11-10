namespace A4aeroTest.Models
{
    public class AuthRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }

        public required string BookingMode { get; set; }
    }
}
