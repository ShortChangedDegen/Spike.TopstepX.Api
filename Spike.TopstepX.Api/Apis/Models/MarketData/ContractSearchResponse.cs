namespace Spike.TopstepX.Api.Apis.Models.MarketData
{
    public record ContractSearchResponse : DefaultResponse
    {
        public required List<Contract> Contracts { get; set; }
    }
}