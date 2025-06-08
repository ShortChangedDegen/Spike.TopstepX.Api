using Refit;
using Spike.TopstepX.Api.Apis;
using Spike.TopstepX.Api.Models.Account;
using System.Text.Json;

namespace Spike.TopstepX.Api.Common
{
    /// <summary>
    /// This class handles authentication with the TopstepX API 
    /// to retrieve an authentication token.
    /// </summary>
    /// <param name="username">The API username.</param>
    /// <param name="apiKey">The API SECRET key.</param>
    /// <param name="apiEndpoint">The API Url.</param>"
    internal class AuthTokenHandler(string username, string apiKey, string apiEndpoint)
    {        
        private string? _token = null;

        /// <summary>
        /// Retrieves an authentication token from the TopstepX API.
        /// </summary>
        /// <returns>A token when successful; otherwise, null.</returns>
        /// <exception cref="HttpRequestException">Thrown when an API request fails.</exception>
        public async Task<string?> GetToken()
        {
            if (!string.IsNullOrEmpty(_token))
            {
                return _token;
            }

            // Unable to use the common method since all other endpoints will
            // require authentication or a token.
            var accountApi = RestService.For<IAccountApi>(apiEndpoint, new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true,
                })
            });

            try
            {
                var response = await accountApi.Authenticate(new AuthenticationRequest
                {
                    UserName = username,
                    ApiKey = apiKey
                });

                if (response.Success)
                {
                    _token = response.Token;
                }
            }
            catch (ApiException refitEx)
            {
                _token = string.Empty;
                // Hide normal implementation details about our inner dependency.
                throw new HttpRequestException($"Authentication failed: {refitEx.Message}", refitEx);
            }

            return _token;
        }
    }
}
