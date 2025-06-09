namespace Spike.ProjectX.Api.Rest.Models.Account
{
    /// <summary>
    /// An account search request.
    /// </summary>
    public class SearchRequest
    {
        /// <summary>
        /// Gets or sets whether to include only active accounts.
        /// </summary>
        public bool OnlyActiveAccounts { get; set; }
    }
}