namespace Spike.TopstepX.Api.Models.Trades
{
    /// <summary>
    /// Represents a request to search for trades within a specific account and time range.
    /// </summary>
    /// <param name="accountId">An account ID.</param>
    /// <param name="startTimestamp">The start timestamp for the search</param>
    /// <param name="endTimestamp">The end timestamp for the search</param>
    public record SearchRequest(int accountId, DateTime startTimestamp, DateTime endTimestamp)
    {
        /// <summary>
        /// Gets the account ID.
        /// </summary>
        public required int AccountId { get; set; } = accountId;
        /// <summary>
        /// Getsthe start timestamp for the search.
        /// </summary>
        public required DateTime StartTimestamp { get; set; } = startTimestamp
        /// <summary>
        /// Gets the end timestamp for the search.
        /// </summary>
        public DateTime EndTimestamp { get; set; } = endTimestamp;
    }
}
