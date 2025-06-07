namespace Spike.TopstepX.Api.Models.Account
{
    /// <summary>
    /// An account search request.
    /// </summary>
    public record SearchRequest
    {
        /// <summary>
        /// Gets or sets whether to include only active accounts.
        /// </summary>
        public bool OnlyActiveAccounts { get; set; }
    }
}