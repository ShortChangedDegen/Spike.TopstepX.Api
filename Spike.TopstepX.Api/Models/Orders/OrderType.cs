namespace Spike.TopstepX.Api.Models.Orders
{
    public enum OrderType
    {
        Unknown = 0,
        Limit = 1,
        Market = 2,
        Stop = 4,        
        TrailingStop = 5,
        JoinBid = 6,
        JoinAsk = 7,
    }
}
