using Spike.TopstepX.Api.Apis.ProjectX;

namespace Spike.TopstepX.Api.Apis
{
    /// <summary>
    /// This 'service locator' will be removed when DI is implemented.
    /// </summary>
    public class ProjectXApi : IProjectXApi
    {
        public IAccountApi Account { get; }
        public IMarketDataApi MarketData { get; }
        public IOrdersApi Orders { get; }
        public IPositionsApi Positions { get; }
        public ITradesApi Trades { get; }
    }
}
