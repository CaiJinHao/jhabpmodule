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
        protected IJhIdentityModelAuthenticationService JhIdentityModelAuthenticationService => LazyServiceProvider.LazyGetRequiredService<IJhIdentityModelAuthenticationService>();
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

            var tokenResponse = await JhIdentityModelAuthenticationService.GetAccessTokenResponseAsync(configuration);
            return ObjectMapper.Map<TokenResponse, AccessTokenResponseDto>(tokenResponse);
        }

        public virtual async Task<AccessTokenResponseDto> GetAccessTokenAsync()
        {
            var configuration = CreateIdentityClientConfiguration();
            configuration.GrantType = OidcConstants.GrantTypes.ClientCredentials;
            configuration.Scope = _identityClientOptions.Audience;

            var tokenResponse = await JhIdentityModelAuthenticationService.GetAccessTokenResponseAsync(configuration);
            return ObjectMapper.Map<TokenResponse, AccessTokenResponseDto>(tokenResponse);
        }

        public virtual async Task<AccessTokenResponseDto> GetRefreshAccessTokenAsync(AccessTokenRefreshDto accessTokenRefreshDto)
        {
            var configuration = CreateIdentityClientConfiguration(accessTokenRefreshDto.OrganizationName);
            configuration.GrantType = OidcConstants.GrantTypes.RefreshToken;

            var tokenResponse = await JhIdentityModelAuthenticationService.GetAccessTokenResponseAsync(configuration, accessTokenRefreshDto.RefreshToken);
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
