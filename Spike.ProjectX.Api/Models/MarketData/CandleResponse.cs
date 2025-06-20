﻿namespace Spike.ProjectX.Api.Models.MarketData
{
    /// <summary>
    /// A response containing a collection of candles.
    /// </summary>
    public record CandleResponse : DefaultResponse
    {
        public List<Candle> Bars { get; set; } = [];
    }
}