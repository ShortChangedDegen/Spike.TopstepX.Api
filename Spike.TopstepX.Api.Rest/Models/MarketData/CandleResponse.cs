using Spike.ProjectX.Api.Rest.Models;
using Spike.ProjectX.Api.Rest.Models.Account;

namespace Spike.ProjectX.Api.Rest.Models.MarketData
{
    /// <summary>
    /// A response containing a collection of candles.
    /// </summary>
    public record CandleResponse : DefaultResponse
    {
        public List<Candle> Candles { get; set; } = [];
    }
}