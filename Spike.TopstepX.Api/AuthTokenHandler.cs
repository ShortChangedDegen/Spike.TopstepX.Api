using Refit;
using Spike.TopstepX.Api.Apis.ProjectX;
using Spike.TopstepX.Api.Models.Account;
using System.Text.Json;

namespace Spike.TopstepX.Api
{
    public class AuthTokenHandler(string username, string apiKey)
    {
        private const string apiEndpoint = "https://api.topstepx.com";
        private string _token = string.Empty;

        public async Task<string?> GetToken()
        {
            if (!string.IsNullOrEmpty(_token))
            {
                return _token;
            }

            var accountApi = RestService.For<IAccountApi>(apiEndpoint, new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                })
            });

            var response = await accountApi.Authenticate(new AuthenticationRequest
            {
                UserName = username,
                ApiKey = apiKey
            });

            if (response.Success)
            {
                _token = response.Token;
                return _token;
            }

            throw new Exception($"Error Authenticating: {response.ErrorCode} - {response.ErrorMessage}");
        }
    }
}
