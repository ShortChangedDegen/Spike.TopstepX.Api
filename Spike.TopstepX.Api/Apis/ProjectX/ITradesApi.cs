using Refit;
using Spike.TopstepX.Api.Models.Trades;

namespace Spike.TopstepX.Api.Apis.ProjectX
{
    [Headers(
        "Accept: application/json", 
        "Content-Type: application/json", 
        "Authorization: Bearer")]    
    public interface ITradesApi
    {
        [Post("api/Trade/search")]
        Task<SearchResponse> GetTrades(SearchRequest request);
    }
}
