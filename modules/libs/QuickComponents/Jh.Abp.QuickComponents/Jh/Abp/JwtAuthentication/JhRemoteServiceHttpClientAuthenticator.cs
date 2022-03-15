using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Client.Authentication;
using Volo.Abp.IdentityModel;

namespace Jh.Abp.QuickComponents
{
    [Dependency(ReplaceServices = true)]
    public class JhRemoteServiceHttpClientAuthenticator : IRemoteServiceHttpClientAuthenticator, ITransientDependency
    {
        protected AbpIdentityClientOptions ClientOptions { get; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }
        protected IIdentityModelAuthenticationService IdentityModelAuthenticationService { get; }
        public JhRemoteServiceHttpClientAuthenticator(
            IOptions<AbpIdentityClientOptions> options,
            IIdentityModelAuthenticationService identityModelAuthenticationService)
        {
            ClientOptions = options.Value;
            IdentityModelAuthenticationService = identityModelAuthenticationService;
        }
        public async Task Authenticate(RemoteServiceHttpClientAuthenticateContext context)
        {
            if (context.RemoteService.GetUseCurrentAccessToken() != false)
            {
                var accessToken = await GetAccessTokenFromHttpContextOrNullAsync();
                if (accessToken != null)
                {
                    context.Request.SetBearerToken(accessToken);
                    return;
                }
            }
        }
        protected virtual async Task<string> GetAccessTokenFromHttpContextOrNullAsync()
        {
            var httpContext = HttpContextAccessor?.HttpContext;
            if (httpContext == null)
            {
                return null;
            }

            return await httpContext.GetTokenAsync("access_token");
        }
    }
}
