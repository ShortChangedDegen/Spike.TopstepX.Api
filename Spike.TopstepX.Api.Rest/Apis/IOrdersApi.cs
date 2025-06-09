using Refit;
using Spike.ProjectX.Api.Rest.Models;
using Spike.ProjectX.Api.Rest.Models.Orders;

namespace Spike.ProjectX.Api.Rest.Apis
{
    [Headers("Authorization: Bearer")]
    public interface IOrdersApi
    {
        [Post("/api/Order/search")] // Get/Post depending on query complexity
        Task<SearchResponse> GetOrders(SearchRequest request);

        [Post("/api/Order/searchOpen")] // Get
        Task<SearchResponse> GetOpenOrders(int accountId);

        [Post("/api/Order/place")] // Post
        Task<CreateResponse> CreateOrder(CreateRequest request);

        [Post("/api/Order/cancel")] //Delete
        Task<DefaultResponse> CancelOrder(CancelRequest request);

        [Post("/api/Order/modify")] // Put
        Task<DefaultResponse> UpdateOrder(UpdateRequest request);
    }
}
