namespace Spike.TopstepX.Api.Apis.Models.Account
{
    public class SearchResponse
    {
        public List<SearchResult> Accounts { get; set; } = new List<SearchResult>();

        public bool Success { get; set; }

        public int ErrorCode { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;
    }
}