namespace Spike.ProjectX.Api.Rest.Models.MarketData
{
    /// <summary>
    /// Represents a single market data candle.
    /// </summary>
    public record Candle
    {
        /// <summary>
        /// Gets or sets the timestamp of the candle.
        /// </summary>
        public DateTime Timestamp { get; set; }
        /// <summary>
        /// Gets or sets the open of the candle.
        /// </summary>
        public decimal Open { get; set; }
        /// <summary>
        /// Gets or sets the open of the candle.
        /// </summary>
        public decimal High { get; set; }
        /// <summary>
        /// Gets or sets the low of the candle.
        /// </summary>
        public decimal Low { get; set; }
        /// <summary>
        /// Gets or sets the close of the candle.
        /// </summary>
        public decimal Close { get; set; }
        /// <summary>
        /// Gets or sets the volume of the candle.
        /// </summary>
        public int Volume { get; set; }
    }
}