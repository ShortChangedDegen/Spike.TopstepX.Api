namespace Spike.ProjectX.Api.Models.MarketData
{
    public record ContractSearchResponse : DefaultResponse
    {
        public List<Contract> Contracts { get; set; } = [];
    }
}