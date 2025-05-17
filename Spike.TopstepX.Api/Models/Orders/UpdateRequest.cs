namespace Spike.TopstepX.Api.Models.Orders
{
    public record UpdateRequest
    {
        public required int AccountId { get; set; }
        public required int OrderId { get; set; }
        public int? Size { get; set; }
        public decimal? LimitPrice { get; set; }
        public decimal? StopPrice { get; set; }
        public decimal? TrailPrice { get; set; }
    }
}
