using Refit;
using Spike.ProjectX.Api.Rest.Models.Account;

namespace Spike.ProjectX.Api.Rest.Apis
{
    public interface IAccountApi
    {
        [Headers("Accept: text/plain", "Content-Type: application/json",
            "Authorization: Bearer")]
        [Post("/api/Account/search")] // Get or post
        Task<SearchResponse> SearchAccounts(SearchRequest request);
                
        [Post("/api/Auth/loginKey")] // Post
        Task<AuthenticationResponse> Authenticate(AuthenticationRequest request);
    }
}
