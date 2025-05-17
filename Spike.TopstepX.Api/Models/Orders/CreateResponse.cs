namespace Spike.TopstepX.Api.Models.Orders
{
    public record CreateResponse : DefaultResponse
    {
        public int OrderId { get; set; }
    }
}
