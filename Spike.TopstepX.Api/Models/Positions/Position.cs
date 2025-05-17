using Spike.TopstepX.Api.Models.Orders;

namespace Spike.TopstepX.Api.Models.Positions
{
    public record Position
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string ContractId { get; set; } = string.Empty;
        public DateTime CreationTimestamp { get; set; }
        public OrderType Type { get; set; }
        public int Size { get; set; }
        public decimal AveragePrice { get; set; }
    }
}
