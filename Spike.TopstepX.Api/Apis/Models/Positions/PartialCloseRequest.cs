namespace Spike.TopstepX.Api.Apis.Models.Positions
{
    public record PartialCloseRequest : CloseRequest
    {
        /// <summary>
        /// Gets or sets the size of the order.
        /// </summary>
        public int Size { get; set; }
    }
}