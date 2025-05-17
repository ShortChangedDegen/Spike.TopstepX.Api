namespace Spike.TopstepX.Api.Models.Trades
{
    public record SearchRequest
    {
        /// <summary>
        /// The account ID.
        /// </summary>
        public required int AccountId { get; set; }
        /// <summary>
        /// Gets or sets the start timestamp for the search.
        /// </summary>
        public required DateTime StartTimestamp { get; set; }
        /// <summary>
        /// Gets or sets the end timestamp for the search.
        /// </summary>
        public DateTime EndTimestamp { get; set; }
    }
}
