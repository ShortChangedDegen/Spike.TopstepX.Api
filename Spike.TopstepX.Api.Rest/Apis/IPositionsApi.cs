using Refit;
using Spike.ProjectX.Api.Rest.Models;
using Spike.ProjectX.Api.Rest.Models.Positions;

namespace Spike.ProjectX.Api.Rest.Apis
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
