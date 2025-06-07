namespace Spike.TopstepX.Api.Apis.Models.Positions
{
    public record SearchResponse : DefaultResponse
    {
        public List<Position> Positions { get; set; } = new List<Position>();
    }
}