namespace Spike.ProjectX.Api.Rest.Models.MarketData
{
    public record ContractSearchResponse : DefaultResponse
    {
        public List<Contract> Contracts { get; set; } = [];
    }
}