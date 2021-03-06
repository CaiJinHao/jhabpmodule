using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Users;

namespace Jh.Abp.JhIdentity.v1
{
    /*
     前端传的时候直接写死，SwaggerApi 参数化了
    [MapToApiVersion("1.0")] 对Action进行版本标记
    默认1.0,方法有几个版本写几个版本
     */
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    //[ApiVersion("3.0")]
    [Authorize]
    [RemoteService(Name = JhIdentityRemoteServiceConsts.RemoteServiceName)]
    [Area(JhIdentityRemoteServiceConsts.ModuleName)]
    [Route("api/v{apiVersion:apiVersion}/[controller]")]
    public class AccessTokenController : JhIdentityController, IAccessTokenAppService
    {
        protected IAccessTokenAppService accessTokenAppService =>LazyServiceProvider.LazyGetService<IAccessTokenAppService>();

        [AllowAnonymous]
        [HttpPost]
        public virtual async Task<AccessTokenResponseDto> GetAccessTokenAsync([FromBody]AccessTokenRequestDto requestDto)
        {
            return await accessTokenAppService.GetAccessTokenAsync(requestDto);
        }

        [Authorize]
        [HttpPost("Refresh")]
        public async Task<AccessTokenResponseDto> GetRefreshAccessTokenAsync([FromBody] AccessTokenRefreshDto accessTokenRefreshDto)
        {
            return await accessTokenAppService.GetRefreshAccessTokenAsync(accessTokenRefreshDto);
        }

        [AllowAnonymous]
        [HttpPost("Token")]
        public async Task<AccessTokenResponseDto> GetAccessTokenAsync(string Audience)
        {
            return await accessTokenAppService.GetAccessTokenAsync(Audience);
        }

        [Route("claims")]
        [HttpGet]
        public dynamic GetClaimsAsync()
        {
            return CurrentUser.GetAllClaims().Select(a => new { a.Type, a.Value });
        }

  

        /*[AllowAnonymous]
        [HttpPost]
        public async Task<AccessTokenResponseDto> GetAccessTokenAsync([FromBody] AccessTokenRequestDto requestDto)
        {
            // discover endpoints from metadata
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest()
            {
                Address = _identityClientOptions.Authority,
                Policy = new DiscoveryPolicy()
                {
                    RequireHttps = _identityClientOptions.RequireHttps
                }
            });
            if (disco.IsError)
            {
                throw new System.Exception("Discovery Error");
            }

            // request token
            var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = _identityClientOptions.ClientId,
                ClientSecret = _identityClientOptions.ClientSecret,
                UserName = requestDto.UserNameOrEmailAddress,
                Password = requestDto.Password,
                Scope = _identityClientOptions.Scope
            });
            if (tokenResponse.IsError)
            {
                throw new System.Exception("Error");
            }
            return new AccessTokenResponseDto()
            {
                AccessToken = tokenResponse.AccessToken,
                ExpiresIn = tokenResponse.ExpiresIn,
                RefreshToken = tokenResponse.RefreshToken,
                TokenType = tokenResponse.TokenType
            };
        }
*/

        /*
         [HttpPost]
        [MapToApiVersion("1.0")]
        public Task<string> PostAsyncV1()
        {
            return PostAsync("v1");
        }

        [HttpPost]
        [MapToApiVersion("2.0")]
        [MapToApiVersion("3.0")]
        public Task<string> PostAsyncV2()
        {
            return PostAsync("v2v3");
        }

        private Task<string> PostAsync(string msg)
        {
            return Task.FromResult($"{msg}-Post-{HttpContext.GetRequestedApiVersion().ToString()}");
        }
        */
    }
}
