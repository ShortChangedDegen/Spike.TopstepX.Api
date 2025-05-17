namespace Spike.TopstepX.Api.Models.Positions
{
    public record SearchResponse : DefaultResponse
    {
        public List<Position> Positions { get; set; } = new List<Position>();
    }
}
