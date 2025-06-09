using Spike.ProjectX.Api.Rest.Models;

namespace Spike.ProjectX.Api.Rest.Models.Orders
{
    /// <summary>
    /// Represents the response from the TopstepX API when creating an order.
    /// </summary>
    /// <param name="orderId">The order ID.</param>
    public record CreateResponse(int? orderId = default) : DefaultResponse
    {
        public int? OrderId { get; set; } = orderId;
    }
}