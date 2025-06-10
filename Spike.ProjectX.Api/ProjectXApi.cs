using Microsoft.Extensions.Options;
using Refit;
using Spike.ProjectX.Api.Models.Account;
using Spike.ProjectX.Api.Rest;
using Spike.ProjectX.Api.Utility;
using System.Text.Json;

namespace Spike.ProjectX.Api
{
    /// <summary>
    /// This service locator or factory will be removed when DI is implemented.
    /// </summary>
    public class ProjectXApi(IOptions<ProjectXSettings> options, AuthTokenHandler authTokenHandler) : IProjectXApi
    {
        private IAccountApi? _accountApi;
        private IMarketDataApi? _marketDataApi;
        private IOrdersApi? _ordersApi;
        private IPositionsApi? _positionsApi;
        private ITradesApi? _tradesApi;

        private AuthTokenHandler _authTokenHandler = authTokenHandler;

        private string _token = string.Empty;
        private System.Timers.Timer _tokenRefreshTimer = new System.Timers.Timer()
        {
            Interval = TimeSpan.FromMinutes(options.Value.TokenExpirationMinutes).TotalMilliseconds, // Default to 60 minutes
        };

        /// <summary>
        /// Gets the account management API for accessing account-related operations.
        /// </summary>
        public virtual IAccountApi Accounts => _accountApi ??= CreateService<IAccountApi>();

        /// <summary>
        /// Gets the market data API for accessing market data operations.
        /// </summary>
        public virtual IMarketDataApi MarketData => _marketDataApi ??= CreateService<IMarketDataApi>();

        /// <summary>
        /// Gets the orders API for accessing order-related operations.
        /// </summary>
        public virtual IOrdersApi Orders => _ordersApi ??= CreateService<IOrdersApi>();

        /// <summary>
        /// Gets the positions API for accessing position-related operations.
        /// </summary>
        public virtual IPositionsApi Positions => _positionsApi ??= CreateService<IPositionsApi>();

        /// <summary>
        /// Gets the trades API for accessing trade-related operations.
        /// </summary>
        public virtual ITradesApi Trades => _tradesApi ??= CreateService<ITradesApi>();

        /// <summary>
        /// Authenticates with the API and cache the token.
        /// </summary>
        /// <returns>A JWT.</returns>
        public virtual async Task<string> Authenticate() => await _authTokenHandler.GetToken();
        
        /// <summary>
        /// Disposes of the API resources.
        /// </summary>
        public virtual void Dispose()
        {
            _tokenRefreshTimer?.Dispose();
            _accountApi = null;
            _marketDataApi = null;
            _ordersApi = null;
            _positionsApi = null;
            _tradesApi = null;
        }

        /// <summary>
        /// Creates a service instance for the specified type using Refit.
        /// </summary>
        /// <typeparam name="T">The type defining the remote REST API.</typeparam>
        /// <returns>The new API service.</returns>
        private T CreateService<T>() => RestService.For<T>(options.Value.ApiUrl, new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            }),

            AuthorizationHeaderValueGetter =
            async (request, cancellationToken) => await Authenticate()
        });
    }
}