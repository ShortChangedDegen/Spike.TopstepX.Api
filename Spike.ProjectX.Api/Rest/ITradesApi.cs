using Refit;
using Spike.ProjectX.Api.Models.Trades;

namespace Spike.ProjectX.Api.Rest
{
    [Headers(
        "Accept: application/json",
        "Content-Type: application/json",
        "Authorization: Bearer")]
    public interface ITradesApi
    {
        [Post("api/Trade/search")] // Get
        Task<SearchResponse> GetTrades(SearchRequest request);
    }
}