namespace Spike.ProjectX.Api.Rest.Models.Orders
{
    /// <summary>
    /// Represents a response containing a list of orders for a specific account.
    /// </summary>
    public record SearchResponse : DefaultResponse
    {
        public List<Order> Orders { get; set; } = [];
    }
}