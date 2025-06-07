using Spike.TopstepX.Api.Models;

namespace Spike.TopstepX.Api.Models.Positions
{
    /// <summary>
    /// Represents a response containing a list of positions.
    /// </summary>
    public record SearchResponse : DefaultResponse<Position>
    {
    }
}