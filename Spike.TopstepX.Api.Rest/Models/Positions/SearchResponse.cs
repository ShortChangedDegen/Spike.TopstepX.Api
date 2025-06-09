using Spike.ProjectX.Api.Rest.Models;
using Spike.ProjectX.Api.Rest.Models.Account;

namespace Spike.ProjectX.Api.Rest.Models.Positions
{
    /// <summary>
    /// Represents a response containing a list of positions.
    /// </summary>
    public record SearchResponse : DefaultResponse
    {
        public List<Position> Positions { get; set; } = [];
    }
}