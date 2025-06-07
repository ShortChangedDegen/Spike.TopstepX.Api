namespace Spike.TopstepX.Api.Apis.Models.Positions
{
    public record CloseRequest
    {
        /// <summary>
        /// The account ID.
        /// </summary>
        public int AccountId { get; set; }
        /// <summary>
        /// 	Gets or sets the contract ID.
        /// </summary>
        public string ContractId { get; set; }
    }
}