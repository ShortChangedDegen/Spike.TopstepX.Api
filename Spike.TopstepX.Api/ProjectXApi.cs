using Refit;
using Spike.TopstepX.Api.Apis;
using Spike.TopstepX.Api.Common;
using System.Text.Json;

namespace Spike.TopstepX.Api
{
    /// <summary>
    /// This service locator or factory will be removed when DI is implemented.
    /// </summary>
    public class ProjectXApi : IProjectXApi
    {        
        public const string DefaultApiEndpoint = "https://api.topstepx.com";
        private const string userName = "<<USERNAME>>";
        private const string apiToken = "<<APITOKEN>>";

        private IAccountApi? _accountApi;
        private IMarketDataApi? _marketDataApi;
        private IOrdersApi? _ordersApi;
        private IPositionsApi? _positionsApi;
        private ITradesApi? _tradesApi;
        private AuthTokenHandler? _tokenStore = null!;

        /// <summary>
        /// Gets the instance of the ProjectXApi.
        /// </summary>
        public static IProjectXApi Instance { get; } = new ProjectXApi();

        /// <summary>
        /// Default constructor for the ProjectXApi class.
        /// </summary>
        private ProjectXApi()
        {
            _tokenStore = new AuthTokenHandler(userName, apiToken, DefaultApiEndpoint);
        }

        /// <summary>
        /// Gets the account management API for accessing account-related operations.
        /// </summary>
        public IAccountApi Accounts => _accountApi ??= CreateService<IAccountApi>();
        /// <summary>
        /// Gets the market data API for accessing market data operations.
        /// </summary>
        public IMarketDataApi MarketData => _marketDataApi ??= CreateService<IMarketDataApi>();
        /// <summary>
        /// Gets the orders API for accessing order-related operations.
        /// </summary>
        public IOrdersApi Orders => _ordersApi ??= CreateService<IOrdersApi>();
        /// <summary>
        /// Gets the positions API for accessing position-related operations.
        /// </summary>
        public IPositionsApi Positions => _positionsApi ??= CreateService<IPositionsApi>();
        /// <summary>
        /// Gets the trades API for accessing trade-related operations.
        /// </summary>
        public ITradesApi Trades => _tradesApi ??= CreateService<ITradesApi>();

        /// <summary>
        /// Creates a service instance for the specified type using Refit.
        /// </summary>
        /// <typeparam name="T">The type defining the remote REST API.</typeparam>
        /// <returns>The new API service.</returns>
        private T CreateService<T>() => RestService.For<T>(DefaultApiEndpoint, new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            }),

            AuthorizationHeaderValueGetter = 
            async (request, cancellationToken) => await _tokenStore.GetToken()
        });
    }
}
