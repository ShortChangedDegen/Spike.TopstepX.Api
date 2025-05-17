namespace Spike.TopstepX.Api.Models.Orders
{
    public class SearchRequest
    {
        public int AccountId { get; set; }
        public required DateTime StartTimestamp { get; set; }
        public DateTime EndTimestamp { get; set; }
    }
}
