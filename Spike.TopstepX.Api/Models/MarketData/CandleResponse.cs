namespace Spike.TopstepX.Api.Models.MarketData
{
    public record CandleResponse : DefaultResponse
    {
        public List<Candle> Bars { get; set; } = new List<Candle>();
    }
}