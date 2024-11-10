using A4aeroTest.Models;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace A4aeroTest.Utilities
{
    public class TBOApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly TBOApiSettings _settings;

        public TBOApiClient(HttpClient httpClient, IOptions<TBOApiSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
        }

        public async Task<AuthResponse> AuthenticateClientAsync()
        {
            var authReq = new AuthRequest
            {
                Username = _settings.Username,
                Password = _settings.Password,
                BookingMode = "API"
            };

            var jsonContent = JsonSerializer.Serialize(authReq);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var res = await _httpClient.PostAsync($"{_settings.BaseUrl}/Authenticate/ValidateAgency", content);

            res.EnsureSuccessStatusCode();

            var resBody = await res.Content.ReadAsStringAsync();

            var ipRes = await _httpClient.GetStringAsync("https://api.ipify.org?format=json");
            var ipJson = JsonSerializer.Deserialize<JsonElement>(ipRes);
            var ipAddress = ipJson.GetProperty("ip").GetString();

            using (JsonDocument doc = JsonDocument.Parse(resBody))
            {
                var combinedRes = new Dictionary<string, object>();

                foreach (var element in doc.RootElement.EnumerateObject())
                {
                    combinedRes[element.Name] = element.Value;
                }

                combinedRes["IPAddress"] = ipAddress;


                var combinedJson = JsonSerializer.Serialize(combinedRes);


                var authRes = JsonSerializer.Deserialize<AuthResponse>(combinedJson);

                return authRes;
            }
        }

        public async Task<List<FlightSearchResponse>> SearchFlightsAsync(TBOFlightSearchRequest req)
        {

            

            var jsonContent = JsonSerializer.Serialize(req);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var res = await _httpClient.PostAsync($"{_settings.BaseUrl}/Search/Search", content);

            res.EnsureSuccessStatusCode();

            var resBody = await res.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(resBody))
            {
                throw new InvalidOperationException("Response body is empty or null.");
            }

            return JsonSerializer.Deserialize<List<FlightSearchResponse>>(resBody);
        }
    }
}
