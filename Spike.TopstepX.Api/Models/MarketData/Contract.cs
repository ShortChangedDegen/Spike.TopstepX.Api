namespace Spike.TopstepX.Api.Models.MarketData
{
    public record Contract
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal TickSize { get; set; }
        public decimal TickValue { get; set; }
        public bool ActiveContract { get; set; }
    }
}