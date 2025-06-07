namespace Spike.TopstepX.Api.Models.Orders
{
    /// <summary>
    /// Represents a request to search for orders.
    /// </summary>
    public class SearchRequest
    {
        /// <summary>
        /// Gets or sets the account ID.
        /// </summary>
        public int AccountId { get; set; }
        /// <summary>
        /// Gets or sets the start timestamp for the search.
        /// </summary>
        public DateTime StartTimestamp { get; set; }
        /// <summary>
        /// Gets or sets the
        /// </summary>
        public DateTime EndTimestamp { get; set; }
    }
}