namespace Spike.TopstepX.Api.Apis.Models.Trades
{
    /// <summary>
    /// Represents a request to search for trades within a specific account
    /// and time range.
    /// </summary>
    /// <param name="accountId">An account ID.</param>
    /// <param name="startTimestamp">The start timestamp for the search</param>
    /// <param name="endTimestamp">The end timestamp for the search</param>
    public record SearchRequest(int accountId = default, DateTime startTimestamp = default, DateTime endTimestamp = default)
    {
        /// <summary>
        /// Gets the account ID.
        /// </summary>
        public int AccountId { get; } = accountId;
        /// <summary>
        /// Getsthe start timestamp for the search.
        /// </summary>
        public DateTime StartTimestamp { get; } = startTimestamp;
        /// <summary>
        /// Gets the end timestamp for the search.
        /// </summary>
        public DateTime EndTimestamp { get; } = endTimestamp;
    }
}