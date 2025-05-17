using Refit;
using Spike.TopstepX.Api.Models.MarketData;

namespace Spike.TopstepX.Api.Apis.ProjectX
{
    [Headers("Authorization: Bearer")]
    public interface IMarketDataApi
    {
        [Post("/api/History/retrieveBars")]
        Task<CandleResponse> GetCandles(CandleRequest request);

        [Post("/api/Contract/search")]
        Task<ContractSearchResponse> GetContracts(ContractSearchRequest request);

        [Post("/api/Contract/searchById")]
        Task<ContractSearchResponse> GetContractsById(string contractId);
    }
}
