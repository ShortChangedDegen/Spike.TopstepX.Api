namespace Spike.TopstepX.Api.Models.MarketData
{
    public record ContractSearchResponse : DefaultResponse
    {
        public required List<Contract> Contracts { get; set; }
    }
}