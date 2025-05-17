using Spike.TopstepX.Api.Apis.ProjectX;
namespace Spike.TopstepX.Api.Apis
{
    public interface IProjectXApi
    {
        IAccountApi Account { get; }
        IMarketDataApi MarketData { get; }
        IOrdersApi Orders { get; }
        IPositionsApi Positions { get; }
        ITradesApi Trades { get; }
    }
}
