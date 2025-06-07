namespace Spike.TopstepX.Api.Apis.Models.MarketData
{
    public record CandleResponse : DefaultResponse
    {
        public List<Candle> Bars { get; set; } = new List<Candle>();
    }
}