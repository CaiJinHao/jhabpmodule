using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer4.Models;
using Microsoft.Extensions.Configuration;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.IdentityServer.ApiScopes;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.IdentityServer.IdentityResources;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Uow;
using ApiResource = Volo.Abp.IdentityServer.ApiResources.ApiResource;
using ApiScope = Volo.Abp.IdentityServer.ApiScopes.ApiScope;
using Client = Volo.Abp.IdentityServer.Clients.Client;

namespace Jh.Abp.WebAppYourName.IdentityServer;

public class IdentityServerDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IApiResourceRepository _apiResourceRepository;
    private readonly IApiScopeRepository _apiScopeRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IIdentityResourceDataSeeder _identityResourceDataSeeder;
    private readonly IGuidGenerator _guidGenerator;
    private readonly IPermissionDataSeeder _permissionDataSeeder;
    private readonly IConfiguration _configuration;
    private readonly ICurrentTenant _currentTenant;

    public IdentityServerDataSeedContributor(
        IClientRepository clientRepository,
        IApiResourceRepository apiResourceRepository,
        IApiScopeRepository apiScopeRepository,
        IIdentityResourceDataSeeder identityResourceDataSeeder,
        IGuidGenerator guidGenerator,
        IPermissionDataSeeder permissionDataSeeder,
        IConfiguration configuration,
        ICurrentTenant currentTenant)
    {
        _clientRepository = clientRepository;
        _apiResourceRepository = apiResourceRepository;
        _apiScopeRepository = apiScopeRepository;
        _identityResourceDataSeeder = identityResourceDataSeeder;
        _guidGenerator = guidGenerator;
        _permissionDataSeeder = permissionDataSeeder;
        _configuration = configuration;
        _currentTenant = currentTenant;
    }

    [UnitOfWork]
    public virtual async Task SeedAsync(DataSeedContext context)
    {
        using (_currentTenant.Change(context?.TenantId))
        {
            await _identityResourceDataSeeder.CreateStandardResourcesAsync();
            await CreateApiResourcesAsync();
            await CreateApiScopesAsync();
            await CreateClientsAsync();
        }
    }

    private async Task CreateApiScopesAsync()
    {
        await CreateApiScopeAsync("WebAppYourName");
    }

    private async Task CreateApiResourcesAsync()
    {
        var commonApiUserClaims = new[]
        {
                "email",
                "email_verified",
                "name",
                "phone_number",
                "phone_number_verified",
                "role"
            };

        await CreateApiResourceAsync("WebAppYourName", commonApiUserClaims);
    }

    private async Task<ApiResource> CreateApiResourceAsync(string name, IEnumerable<string> claims)
    {
        var apiResource = await _apiResourceRepository.FindByNameAsync(name);
        if (apiResource == null)
        {
            apiResource = await _apiResourceRepository.InsertAsync(
                new ApiResource(
                    _guidGenerator.Create(),
                    name,
                    name + " API"
                ),
                autoSave: true
            );
        }

        foreach (var claim in claims)
        {
            if (apiResource.FindClaim(claim) == null)
            {
                apiResource.AddUserClaim(claim);
            }
        }

        return await _apiResourceRepository.UpdateAsync(apiResource);
    }

    private async Task<ApiScope> CreateApiScopeAsync(string name)
    {
        var apiScope = await _apiScopeRepository.FindByNameAsync(name);
        if (apiScope == null)
        {
            apiScope = await _apiScopeRepository.InsertAsync(
                new ApiScope(
                    _guidGenerator.Create(),
                    name,
                    name + " API"
                ),
                autoSave: true
            );
        }

        return apiScope;
    }

    private async Task CreateClientsAsync()
    {
        var commonScopes = new[]
        {
                "email",
                "openid",
                "profile",
                "role",
                "phone",
                "address",
                "WebAppYourName"
            };

        var configurationSection = _configuration.GetSection("IdentityServer:Clients");

        //TODO:���JS Client
        var clientName = _configuration.GetValue<string>("AuthServer:ApiName");
        var jsClientId = configurationSection[$"{clientName}_Js:ClientId"];
        if (!jsClientId.IsNullOrWhiteSpace())
        {
            var webClientRootUrl = configurationSection[$"{clientName}_Js:RootUrl"].EnsureEndsWith('/');
            var redirectUri = configurationSection[$"{clientName}_Js:RedirectUri"];
            var postLogoutRedirectUri = configurationSection[$"{clientName}_Js:postLogoutRedirectUri"];
            var frontChannelLogoutUri = configurationSection[$"{clientName}_Js:frontChannelLogoutUri"];

            /* JhIdentity_Web client is only needed if you created a tiered
             * solution. Otherwise, you can delete this client. */

            await CreateClientAsync(
                name: jsClientId,
                scopes: commonScopes,
                grantTypes: new[] { "implicit" },
                secret: (configurationSection[$"{clientName}_Js:ClientSecret"] ?? "KimHo@666").Sha256(),
                redirectUri: redirectUri,
                postLogoutRedirectUri: postLogoutRedirectUri,//��Ҫ�Ϳͻ�������һ�²�����ת
                frontChannelLogoutUri: frontChannelLogoutUri,
                corsOrigins: new[] { webClientRootUrl.RemovePostFix("/") }
            );
        }

        //Web Client
        var webClientId = configurationSection["WebAppYourName_Web:ClientId"];
        if (!webClientId.IsNullOrWhiteSpace())
        {
            var webClientRootUrl = configurationSection["WebAppYourName_Web:RootUrl"].EnsureEndsWith('/');

            /* WebAppYourName_Web client is only needed if you created a tiered
             * solution. Otherwise, you can delete this client. */

            await CreateClientAsync(
                name: webClientId,
                scopes: commonScopes,
                grantTypes: new[] { "hybrid" },
                secret: (configurationSection["WebAppYourName_Web:ClientSecret"] ?? "KimHo@666").Sha256(),
                redirectUri: $"{webClientRootUrl}",//signin-oidc
                postLogoutRedirectUri: $"{webClientRootUrl}signout-callback-oidc",
                frontChannelLogoutUri: $"{webClientRootUrl}Account/FrontChannelLogout",
                corsOrigins: new[] { webClientRootUrl.RemovePostFix("/") }
            );
        }

        //Console Test / Angular Client
        var consoleAndAngularClientId = configurationSection["WebAppYourName_App:ClientId"];
        if (!consoleAndAngularClientId.IsNullOrWhiteSpace())
        {
            var webClientRootUrl = configurationSection["WebAppYourName_App:RootUrl"]?.TrimEnd('/');

            await CreateClientAsync(
                name: consoleAndAngularClientId,
                scopes: commonScopes,
                grantTypes: new[] { "password", "client_credentials", "authorization_code" },
                secret: (configurationSection["WebAppYourName_App:ClientSecret"] ?? "KimHo@666").Sha256(),
                requireClientSecret: false,
                redirectUri: webClientRootUrl,
                postLogoutRedirectUri: webClientRootUrl,
                corsOrigins: new[] { webClientRootUrl.RemovePostFix("/") }
            );
        }

        // Blazor Client
        var blazorClientId = configurationSection["WebAppYourName_Blazor:ClientId"];
        if (!blazorClientId.IsNullOrWhiteSpace())
        {
            var blazorRootUrl = configurationSection["WebAppYourName_Blazor:RootUrl"].TrimEnd('/');

            await CreateClientAsync(
                name: blazorClientId,
                scopes: commonScopes,
                grantTypes: new[] { "authorization_code" },
                secret: configurationSection["WebAppYourName_Blazor:ClientSecret"]?.Sha256(),
                requireClientSecret: false,
                redirectUri: $"{blazorRootUrl}/authentication/login-callback",
                postLogoutRedirectUri: $"{blazorRootUrl}/authentication/logout-callback",
                corsOrigins: new[] { blazorRootUrl.RemovePostFix("/") }
            );
        }

        // Swagger Client
        var swaggerClientId = configurationSection["WebAppYourName_Swagger:ClientId"];
        if (!swaggerClientId.IsNullOrWhiteSpace())
        {
            var swaggerRootUrl = configurationSection["WebAppYourName_Swagger:RootUrl"].TrimEnd('/');

            await CreateClientAsync(
                name: swaggerClientId,
                scopes: commonScopes,
                grantTypes: new[] { "authorization_code" },
                secret: configurationSection["WebAppYourName_Swagger:ClientSecret"]?.Sha256(),
                requireClientSecret: false,
                redirectUri: $"{swaggerRootUrl}/swagger/oauth2-redirect.html",
                corsOrigins: new[] { swaggerRootUrl.RemovePostFix("/") }
            );
        }
    }

    private async Task<Client> CreateClientAsync(
        string name,
        IEnumerable<string> scopes,
        IEnumerable<string> grantTypes,
        string secret = null,
        string redirectUri = null,
        string postLogoutRedirectUri = null,
        string frontChannelLogoutUri = null,
        bool requireClientSecret = true,
        bool requirePkce = false,
        IEnumerable<string> permissions = null,
        IEnumerable<string> corsOrigins = null)
    {
        var client = await _clientRepository.FindByClientIdAsync(name);
        if (client == null)
        {
            client = await _clientRepository.InsertAsync(
                new Client(
                    _guidGenerator.Create(),
                    name
                )
                {
                    AllowAccessTokensViaBrowser=true,//TODO:modify
                    ClientName = name,
                    ProtocolType = "oidc",
                    Description = name,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AllowOfflineAccess = true,
                    AbsoluteRefreshTokenLifetime = 31536000, //365 days
                        AccessTokenLifetime = 31536000, //365 days
                        AuthorizationCodeLifetime = 300,
                    IdentityTokenLifetime = 300,
                    RequireConsent = false,
                    FrontChannelLogoutUri = frontChannelLogoutUri,
                    RequireClientSecret = requireClientSecret,
                    RequirePkce = requirePkce
                },
                autoSave: true
            );
        }

        foreach (var scope in scopes)
        {
            if (client.FindScope(scope) == null)
            {
                client.AddScope(scope);
            }
        }

        foreach (var grantType in grantTypes)
        {
            if (client.FindGrantType(grantType) == null)
            {
                client.AddGrantType(grantType);
            }
        }

        if (!secret.IsNullOrEmpty())
        {
            if (client.FindSecret(secret) == null)
            {
                client.AddSecret(secret);
            }
        }

        if (redirectUri != null)
        {
            if (client.FindRedirectUri(redirectUri) == null)
            {
                client.AddRedirectUri(redirectUri);
            }
        }

        if (postLogoutRedirectUri != null)
        {
            if (client.FindPostLogoutRedirectUri(postLogoutRedirectUri) == null)
            {
                client.AddPostLogoutRedirectUri(postLogoutRedirectUri);
            }
        }

        if (permissions != null)
        {
            await _permissionDataSeeder.SeedAsync(
                ClientPermissionValueProvider.ProviderName,
                name,
                permissions,
                null
            );
        }

        if (corsOrigins != null)
        {
            foreach (var origin in corsOrigins)
            {
                if (!origin.IsNullOrWhiteSpace() && client.FindCorsOrigin(origin) == null)
                {
                    client.AddCorsOrigin(origin);
                }
            }
        }

        return await _clientRepository.UpdateAsync(client);
    }
}
