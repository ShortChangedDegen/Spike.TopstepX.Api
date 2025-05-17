namespace Spike.TopstepX.Api.Models.Trades
{
    public record SearchResponse : DefaultResponse
    {
        /// <summary>
        ///     Gets or sets the list of trades.
        /// </summary>
        public List<Trade> Trades { get; set; } = new List<Trade>();
    }
}
