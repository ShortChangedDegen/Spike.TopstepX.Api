namespace Spike.TopstepX.Api.Models.Account
{
    /// <summary>
    /// An account search result.
    /// </summary>
    public record SearchResult
    {
        /// <summary>
        /// Gets or sets the unique identifier for the account.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the account.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the account balance.
        /// </summary>
        public double Balance { get; set; }

        /// <summary>
        /// Gets or sets whether the account can trade.
        /// </summary>
        public bool CanTrade { get; set; }

        /// <summary>
        /// Gets or sets whether the account is visible.
        /// </summary>
        public bool IsVisible { get; set; }
    }
}