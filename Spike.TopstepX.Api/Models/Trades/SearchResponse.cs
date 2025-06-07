namespace Spike.TopstepX.Api.Models.Trades
{
    /// <summary>
    /// Represents a response containing a list of trades for a specific account.
    /// </summary>
    /// <param name="trades">The <see cref="List{Trade}" /> of matching trades.</param>
    public record SearchResponse(List<Trade> trades = default!) : DefaultResponse
    {
        /// <summary>  
        ///     Gets or sets a <see cref="List{Trade}" /> of matching trades.
        /// </summary>  
        public required List<Trade> Trades { get; set; } = trades;
    }
}
