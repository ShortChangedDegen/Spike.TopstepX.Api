namespace Spike.TopstepX.Api.Apis.Models.Orders
{
    public record SearchResponse : DefaultResponse
    {
        public List<Order> Orders { get; set; } = default!;
    }
}