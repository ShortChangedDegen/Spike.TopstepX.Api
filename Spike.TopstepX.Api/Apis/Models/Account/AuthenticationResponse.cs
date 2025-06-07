namespace Spike.TopstepX.Api.Apis.Models.Account
{
    public record AuthenticationResponse : DefaultResponse
    {
        public string Token { get; set; }
    }
}