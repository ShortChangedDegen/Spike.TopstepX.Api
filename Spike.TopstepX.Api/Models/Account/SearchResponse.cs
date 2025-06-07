namespace Spike.TopstepX.Api.Models.Account
{
    /// <summary>
    /// Represents a response containing a list of accounts.
    /// </summary>
    /// <param name="accounts">The matching accounts.</param>
    public record SearchResponse() : DefaultResponse<SearchResult>
    {
    }
}