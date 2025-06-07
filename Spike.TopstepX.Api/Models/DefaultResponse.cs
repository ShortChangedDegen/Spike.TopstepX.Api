namespace Spike.TopstepX.Api.Models
{
    /// <summary>
    /// Represents a default response structure for API calls.
    /// </summary>
    public record DefaultResponse
    {
        /// <summary>
        /// Gets a value indicating whether the response was successful.
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Gets a rudimentary error code. 0 indicates no error.
        /// </summary>
        public int ErrorCode { get; set; }
        /// <summary>
        /// Gets a more specific error message. An empty string indicates
        /// no error.
        /// </summary>
        public string ErrorMessage { get; set; }
    }

    /// <summary>
    /// Represents a default response structure for API calls.
    /// </summary>
    /// <param name="success">Whether the response is successful.</param>
    /// <param name="errorCode">A rudimentary error code.</param>
    /// <param name="errorMessage">A more specific error message.</param>
    public record DefaultResponse<T>() : DefaultResponse
    {
        /// <summary>
        /// Gets a list of payload items.
        /// </summary>
        public List<T> Payload { get; protected set; } = default!;
    }
}