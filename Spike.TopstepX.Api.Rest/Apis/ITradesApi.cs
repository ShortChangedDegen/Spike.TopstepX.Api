using Refit;
using Spike.ProjectX.Api.Rest.Models.Trades;

namespace Spike.ProjectX.Api.Rest.Apis
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
