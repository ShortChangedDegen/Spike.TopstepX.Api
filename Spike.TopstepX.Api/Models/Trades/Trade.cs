using Spike.TopstepX.Api.Models.Orders;

namespace Spike.TopstepX.Api.Models.Trades
{
    public record Trade
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string ContractId { get; set; } = string.Empty;
        public DateTime CreationTimestamp { get; set; }
        public decimal Price { get; set; }
        public decimal ProfitAndLoss { get; set; }
        public decimal Fees { get; set; }
        public Side Side { get; set; }
        public int Size { get; set; } 
        public bool Voided { get; set; }
        public int OrderId { get; set; }
    }
}
