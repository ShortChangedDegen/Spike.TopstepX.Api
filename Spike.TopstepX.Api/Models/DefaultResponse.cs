namespace Spike.TopstepX.Api.Models
{
    /// <summary>
    /// Represents a default response structure for API calls.
    /// </summary>
    /// <param name="success">Whether the response is successful.</param>
    /// <param name="errorCode">A rudimentary error code.</param>
    /// <param name="errorMessage">A more specific error message.</param>
    public record DefaultResponse(bool success = true, int errorCode = 0, string errorMessage = "")
    {
        /// <summary>
        /// Gets a value indicating whether the response was successful.
        /// </summary>
        public bool Success { get; } = success;
        /// <summary>
        /// Gets a rudimentary error code. 0 indicates no error.
        /// </summary>
        public int ErrorCode { get; } = errorCode = 0;
        /// <summary>
        /// Gets a more specific error message. An empty string indicates no error.
        /// </summary>
        public string ErrorMessage { get; } = errorMessage;        
    }
}
