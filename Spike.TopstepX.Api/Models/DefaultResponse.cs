namespace Spike.TopstepX.Api.Models
{
    public record DefaultResponse
    {
        public bool Success { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;        
    }
}
