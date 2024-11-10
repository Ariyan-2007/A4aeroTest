using A4aeroTest.Models;

namespace A4aeroTest.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponse> GetAuthInfoAsync();
    }
}
