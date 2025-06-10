namespace Spike.ProjectX.Api.Models.MarketData
{
    /// <summary>
    /// Represents a market quote event containing
    /// the best bid and ask prices for a specific instrument.
    /// </summary>
    public record MarketQuoteEvent : IEvent
    {
        /// <summary>
        /// Gets or sets the instrument identifier for the quote.
        /// </summary>
        public required string Symbol { get; set; }

        /// <summary>
        /// Gets or sets the best bid price for the quote.
        /// </summary>
        public decimal BestBid { get; set; }

        /// <summary>
        /// Gets or sets the best ask price for the quote.
        /// </summary>
        public decimal BestAsk { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the quote.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the last updated timestamp of the quote.
        /// </summary>
        public DateTime LastUpdated { get; set; }
    }
}