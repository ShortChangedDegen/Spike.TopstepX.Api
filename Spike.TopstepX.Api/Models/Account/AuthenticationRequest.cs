namespace Spike.TopstepX.Api.Models.Account
{
    public record AuthenticationRequest
    {
        public string UserName { get; set; }
        public string ApiKey { get; set; }
    }
}