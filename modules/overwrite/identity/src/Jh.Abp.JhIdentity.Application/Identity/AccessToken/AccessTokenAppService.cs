using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.IdentityModel;
using Volo.Abp.ObjectMapping;

namespace Jh.Abp.JhIdentity
{
    public class AccessTokenAppService :ApplicationService, IAccessTokenAppService, ITransientDependency
    {
        protected IJhIdentityModelAuthenticationService jhIdentityModelAuthenticationService => LazyServiceProvider.LazyGetRequiredService<IJhIdentityModelAuthenticationService>();
        protected readonly IdentityClientOptions _identityClientOptions;
        public AccessTokenAppService(
            IOptions<IdentityClientOptions> identityClientOptions
            )
        {
            _identityClientOptions = identityClientOptions.Value;
        }


        public virtual async Task<AccessTokenResponseDto> GetAccessTokenAsync(AccessTokenRequestDto requestDto)
        {
            var configuration = CreateIdentityClientConfiguration(requestDto.OrganizationName);
            configuration.GrantType = OidcConstants.GrantTypes.Password;
            configuration.UserName = requestDto.UserNameOrEmailAddress;
            configuration.UserPassword = requestDto.Password;

            var tokenResponse = await jhIdentityModelAuthenticationService.GetAccessTokenResponseAsync(configuration);
            return ObjectMapper.Map<TokenResponse, AccessTokenResponseDto>(tokenResponse);
        }

        [Authorize]
        public virtual async Task<AccessTokenResponseDto> GetRefreshAccessTokenAsync(string refreshToken, string organizationName = null)
        {
            var configuration = CreateIdentityClientConfiguration(organizationName);
            configuration.GrantType = OidcConstants.GrantTypes.RefreshToken;

            var tokenResponse = await jhIdentityModelAuthenticationService.GetAccessTokenResponseAsync(configuration, refreshToken);
            return ObjectMapper.Map<TokenResponse, AccessTokenResponseDto>(tokenResponse);
        }

        protected virtual IdentityClientConfiguration CreateIdentityClientConfiguration(string organizationName = null)
        {
            var configuration = new IdentityClientConfiguration(
                _identityClientOptions.Authority,
                _identityClientOptions.Scope,
                _identityClientOptions.ClientId,
                _identityClientOptions.ClientSecret
            )
            {
                RequireHttps = _identityClientOptions.RequireHttps
            };
            if (!organizationName.IsNullOrWhiteSpace())
            {
                configuration["[o]abp-organization-name"] = organizationName;
            }
            return configuration;
        }
    }
}
