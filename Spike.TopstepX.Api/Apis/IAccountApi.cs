using Refit;
using Spike.TopstepX.Api.Models.Account;

namespace Spike.TopstepX.Api.Apis
{
    public interface IAccountApi
    {
        [Headers("Accept: text/plain", "Content-Type: application/json",
            "Authorization: Bearer")]
        [Post("/api/Account/search")]
        Task<SearchResponse> SearchAccounts(SearchRequest request);
                
        [Post("/api/Auth/loginKey")]
        Task<AuthenticationResponse> Authenticate(AuthenticationRequest request);
    }
}
