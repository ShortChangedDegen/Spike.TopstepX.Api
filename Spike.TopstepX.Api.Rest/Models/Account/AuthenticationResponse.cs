using Spike.ProjectX.Api.Rest.Models;

namespace Spike.ProjectX.Api.Rest.Models.Account
{
    /// <summary>
    /// An authentication response containing an access token when successful.
    /// </summary>
    public record AuthenticationResponse : DefaultResponse
    {
        /// <summary>
        /// Gets or sets the access token for authenticated requests.
        /// </summary>
        public string? Token { get; set; }
    }
}