using A4aeroTest.Models;
using A4aeroTest.Services.Interfaces;
using A4aeroTest.Utilities;

namespace A4aeroTest.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly TBOApiClient _client;
        private AuthResponse? _auth;
        public AuthService(TBOApiClient client) {
            _client = client;
        }

        public async Task<AuthResponse> GetAuthInfoAsync()
        {

                _auth = await _client.AuthenticateClientAsync();

            return _auth;
        }

    }
}
