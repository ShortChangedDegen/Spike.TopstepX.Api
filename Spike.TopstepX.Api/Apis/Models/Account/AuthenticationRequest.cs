namespace Spike.TopstepX.Api.Apis.Models.Account
{
    public record AuthenticationRequest
    {
        public string UserName { get; set; }
        public string ApiKey { get; set; }
    }
}