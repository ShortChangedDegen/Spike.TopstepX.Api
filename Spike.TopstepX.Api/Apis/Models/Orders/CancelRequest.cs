namespace Spike.TopstepX.Api.Apis.Models.Orders
{
    public record CancelRequest
    {
        public int AccountId { get; set; }
        public int OrderId { get; set; }
    }
}