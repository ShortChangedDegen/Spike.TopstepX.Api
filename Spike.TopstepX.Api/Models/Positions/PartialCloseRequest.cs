namespace Spike.TopstepX.Api.Models.Positions
{
    public record PartialCloseRequest : CloseRequest
    {
        /// <summary>
        /// Gets or sets the size of the order.
        /// </summary>
        public int Size { get; set; }
    }
}
