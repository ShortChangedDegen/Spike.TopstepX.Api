using Microsoft.Extensions.Options;
using Refit;
using Spike.ProjectX.Api.Models.Account;
using Spike.ProjectX.Api.Rest;
using System.Text.Json;

namespace Spike.ProjectX.Api.Utility
{
    /// <summary>
    /// This class handles authentication with the TopstepX API
    /// to retrieve an authentication token.
    /// </summary>
    /// <param name="username">The API username.</param>
    /// <param name="apiKey">The API SECRET key.</param>
    /// <param name="apiEndpoint">The API Url.</param>"
    public class AuthTokenHandler(IOptions<ProjectXSettings> options)
    {
        private string? _token = null;

        /// <summary>
        /// Creates a new instance of the AuthTokenHandler class.
        /// </summary>
        /// <param name="username">The API username.</param>
        /// <param name="apiKey">The API SECRET key.</param>
        /// <param name="apiEndpoint">The API Url.</param>"
        public AuthTokenHandler(string username, string apiKey, string apiEndpoint)
            : this(Options.Create(new ProjectXSettings
            {
                Username = username,
                ApiKey = apiKey,
                ApiUrl = apiEndpoint,
                UserHubUrl = string.Empty, // Provide a default value or retrieve from configuration
                MarketHubUrl = string.Empty // Provide a default value or retrieve from configuration
            }))
        {
        }

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
            var accountApi = RestService.For<IAccountApi>(options.Value.ApiUrl, new RefitSettings
            {
                ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = false
                }),
            });

            try
            {
                var response = await accountApi.Authenticate(new AuthenticationRequest
                {
                    UserName = options.Value.Username,
                    ApiKey = options.Value.ApiKey
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