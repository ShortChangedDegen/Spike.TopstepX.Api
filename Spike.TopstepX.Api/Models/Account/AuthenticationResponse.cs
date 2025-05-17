namespace Spike.TopstepX.Api.Models.Account
{
    public record AuthenticationResponse : DefaultResponse
    {
        public string Token { get; set; }
    }
}