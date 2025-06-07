using Refit;
using Spike.TopstepX.Api.Apis.ProjectX;
using System.Text.Json;

namespace Spike.TopstepX.Api.Apis
{
    /// <summary>
    /// This service locator or factory will be removed when DI is implemented.
    /// </summary>
    public class ProjectXApi : IProjectXApi
    {
        private AuthTokenHandler? _tokenStore = null!;
        private const string userName = "amarquette78";
        private const string apiToken = "/TsvJTH/zzIpTbF9rqLrs24ZiFCtrNW2hY23wTksffc=";

        public const string DefaultApiEndpoint = "https://api.topstepx.com";
        public static ProjectXApi Instance { get; } = new ProjectXApi();

        private ProjectXApi()
        {
            _tokenStore = new AuthTokenHandler(userName, apiToken);
        }
        
        private IAccountApi? _accountApi;
        private IMarketDataApi? _marketDataApi;
        private IOrdersApi? _ordersApi;
        private IPositionsApi? _positionsApi;
        private ITradesApi? _tradesApi;

        public IAccountApi Accounts => _accountApi ??= CreateService<IAccountApi>();
        public IMarketDataApi MarketData => _marketDataApi ??= CreateService<IMarketDataApi>();
        public IOrdersApi Orders => _ordersApi ??= CreateService<IOrdersApi>();
        public IPositionsApi Positions => _positionsApi ??= CreateService<IPositionsApi>();
        public ITradesApi Trades => _tradesApi ??= CreateService<ITradesApi>();


        private T CreateService<T>() => RestService.For<T>(DefaultApiEndpoint, new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            }),

            AuthorizationHeaderValueGetter = 
            async (request, cancellationToken) => await _tokenStore.GetToken(),
        });
    }
}
