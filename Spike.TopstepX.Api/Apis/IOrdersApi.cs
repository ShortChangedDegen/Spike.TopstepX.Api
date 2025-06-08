using Refit;
using Spike.TopstepX.Api.Models;
using Spike.TopstepX.Api.Models.Orders;

namespace Spike.TopstepX.Api.Apis
{
    [Headers("Authorization: Bearer")]
    public interface IOrdersApi
    {
        [Post("/api/Order/search")]
        Task<SearchResponse> GetOrders(SearchRequest request);

        [Post("/api/Order/searchOpen")]
        Task<SearchResponse> GetOpenOrders(int accountId);

        [Post("/api/Order/place")]
        Task<CreateResponse> CreateOrder(CreateRequest request);

        [Post("/api/Order/cancel")]
        Task<DefaultResponse> CancelOrder(CancelRequest request);

        [Post("/api/Order/modify")]
        Task<DefaultResponse> UpdateOrder(UpdateRequest request);
    }
}
