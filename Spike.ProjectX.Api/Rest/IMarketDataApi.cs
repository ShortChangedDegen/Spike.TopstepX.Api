using Refit;
using Spike.ProjectX.Api.Models.MarketData;

namespace Spike.ProjectX.Api.Rest
{
    [Headers("Authorization: Bearer")]
    public interface IMarketDataApi
    {
        [Post("/api/History/retrieveBars")] // Get
        Task<CandleResponse> GetCandles(CandleRequest request);

        [Post("/api/Contract/search")] // Get/Post
        Task<ContractSearchResponse> GetContracts(ContractSearchRequest request);

        [Post("/api/Contract/searchById")] // Get
        Task<ContractSearchResponse> GetContractsById(string contractId);
    }
}