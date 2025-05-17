namespace Spike.TopstepX.Api.Models.Orders
{
    public record SearchResponse : DefaultResponse
    {
        public List<Order> Orders { get; set; } = default!;
    }
}
