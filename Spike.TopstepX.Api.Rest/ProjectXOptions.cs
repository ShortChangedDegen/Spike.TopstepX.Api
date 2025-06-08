using System.ComponentModel.DataAnnotations;

namespace Spike.ProjectX.Api.Rest
{
    /// <summary>
    /// Represents the configuration options for the TopstepX API client.
    /// </summary>
    public record ProjectXOptions
    {
        /// <summary>
        /// Gets the section name.
        /// </summary>
        public string SectionName => "ProjectX";

        /// <summary>
        /// Gets or sets the username for the API authentication.
        /// </summary>
        [Required]
        public required string Username { get; set; }
        /// <summary>
        /// Gets or sets the API key for the API authentication.
        /// </summary>
        [Required]
        public required string ApiKey { get; set; }
        /// <summary>
        /// Gets or sets the base URL for the TopstepX API.
        /// </summary>
        [Required]
        public required string BaseUrl { get; set; }
    }
}
