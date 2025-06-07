namespace Spike.TopstepX.Api.Apis.Models.Orders
{
    public record CreateResponse : DefaultResponse
    {
        public int OrderId { get; set; }
    }
}