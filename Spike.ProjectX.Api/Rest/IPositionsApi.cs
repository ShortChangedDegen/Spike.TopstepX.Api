using Refit;
using Spike.ProjectX.Api.Models;
using Spike.ProjectX.Api.Models.Positions;

namespace Spike.ProjectX.Api.Rest
{
    [Headers("Authorization: Bearer")]
    public interface IPositionsApi
    {
        [Post("/api/Position/closeContract")] //Put
        Task<DefaultResponse> CloseContract(CloseRequest request);

        [Post("/api/Position/partialCloseContract")] // Put
        Task<DefaultResponse> PartiallyCloseContract(PartialCloseRequest request);

        [Post("/api/Position/searchOpen")] // Get
        Task<SearchResponse> SearchOpenPositions(int accountId);
    }
}