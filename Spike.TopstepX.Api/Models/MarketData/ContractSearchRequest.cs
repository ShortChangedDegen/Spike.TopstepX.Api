namespace Spike.TopstepX.Api.Models.MarketData
{
    public class ContractSearchRequest
    {
        /// <summary>
        /// The name of the contract to search for.
        /// </summary>
        public string SearchText { get; set; } = string.Empty;

        /// <summary>
        /// Whether to search for contracts using the sim/live data subscription.
        /// </summary>
        public bool Live { get; set; } = true;

        /// <summary>
        /// The id of the contract to search for.
        /// </summary>
        public string ContractId { get; set; } = string.Empty;
    }
}