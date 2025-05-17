namespace Spike.TopstepX.Api.Models.Orders
{
    public record Order
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string ContractId { get; set; } = string.Empty;
        public DateTime CreationTimestamp { get; set; }
        public DateTime UpdateTimestamp { get; set; }
        public int Status { get; set; }
        public OrderType Type { get; set; }
        public Side Side { get; set; }
        public int Size { get; set; }
        public double? LimitPrice { get; set; }
        public double? StopPrice { get; set; }
    }
}
