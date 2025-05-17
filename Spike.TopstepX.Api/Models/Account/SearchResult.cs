namespace Spike.TopstepX.Api.Models.Account
{
    public record SearchResult
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Balance { get; set; }
        public bool CanTrade { get; set; }
        public bool IsVisible { get; set; }
    }
}