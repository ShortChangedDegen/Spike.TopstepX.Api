using Spike.ProjectX.Api.Rest.Models;

namespace Spike.ProjectX.Api.Rest.Models.Account
{
    /// <summary>
    /// Represents a response containing a list of accounts.
    /// </summary>
    /// <param name="accounts">The matching accounts.</param>
    public record SearchResponse() : DefaultResponse
    {
        public List<SearchResult> Accounts { get; set; } = [];
    }
}