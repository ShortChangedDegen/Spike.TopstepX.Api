namespace Spike.TopstepX.Api.Models.Account
{
    /// <summary>
    /// An authentication request.
    /// </summary>
    public record AuthenticationRequest
    {
        /// <summary>
        /// Gets or sets the username for the API authentication.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the API key for the API authentication.
        /// </summary>
        public string ApiKey { get; set; }
    }
}