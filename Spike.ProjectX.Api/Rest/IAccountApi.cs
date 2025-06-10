using Refit;
using Spike.ProjectX.Api.Models.Account;

namespace Spike.ProjectX.Api.Rest
{
    public interface IAccountApi
    {
        [Headers("Accept: text/plain", "Content-Type: application/json",
            "Authorization: Bearer")]
        [Post("/api/Account/search")] // Get or post
        Task<AccountSearchResponse> SearchAccounts(AccountSearchRequest request);

        [Post("/api/Auth/loginKey")] // Post
        Task<AuthenticationResponse> Authenticate(AuthenticationRequest request);
    }
}