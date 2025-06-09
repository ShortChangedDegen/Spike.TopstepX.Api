using Spike.ProjectX.Api.Rest.Models;
using Spike.ProjectX.Api.Rest.Models.Account;

namespace Spike.ProjectX.Api.Rest.Models.Trades
{
    /// <summary>
    /// Represents a response containing a list of trades for a
    /// specific account.
    /// </summary>
    public record SearchResponse : DefaultResponse
    {
        public List<Trade> Accounts { get; set; } = [];
    }
}