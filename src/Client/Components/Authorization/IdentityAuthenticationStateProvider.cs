using HykeIt.Infrastructure;
using HykeIt.Models.Identity;
using HykeIt.Models.Site;
using HykeIt.Security;

using Microsoft.AspNetCore.Components.Authorization;

using System.Net.Http.Json;
using System.Security.Claims;

namespace HykeIt.Components.Authorization
{
    public class IdentityAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public IdentityAuthenticationStateProvider(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsIdentity identity = new();
            var http = _serviceProvider.GetRequiredService<HttpClient>();
            var state = _serviceProvider.GetRequiredService<SiteState>();
            var user = await http.GetFromJsonAsync<User>(
                Utilities.TenantUrl(
                    state.Alias,
                    "/api/User/authenticate"));
            if (user.IsAuthenticated)
            {
                identity = UserIdentity.CreateClaimsIdentity(state.Alias, user);
            }
            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        public void NotifyAuthenticationChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
