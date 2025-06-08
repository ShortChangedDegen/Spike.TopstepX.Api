using Refit;
using Spike.TopstepX.Api.Models;
using Spike.TopstepX.Api.Models.Positions;

namespace Spike.TopstepX.Api.Apis
{
    [Headers("Authorization: Bearer")]
    public interface IPositionsApi
    {
        [Post("/api/Position/closeContract")]
        Task<DefaultResponse> CloseContract(CloseRequest request);

        [Post("/api/Position/partialCloseContract")]
        Task<DefaultResponse> PartiallyCloseContract(PartialCloseRequest request);

        [Post("/api/Position/searchOpen")]
        Task<SearchResponse> SearchOpenPositions(int accountId);
    }
}
