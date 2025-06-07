namespace Spike.TopstepX.Api.Apis.Models.Orders
{
    public class SearchRequest
    {
        public int AccountId { get; set; }
        public DateTime StartTimestamp { get; set; }
        public DateTime EndTimestamp { get; set; }
    }
}