﻿using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Jh.Abp.JhIdentity;

[DependsOn(
    typeof(JhIdentityDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class JhIdentityApplicationContractsModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        Configure<IdentityClientOptions>(options =>
        {
            options.Authority = configuration["AuthServer:Authority"];
            options.ClientId = configuration["AuthServer:AppClientId"];
            options.ClientSecret = configuration["AuthServer:AppClientSecret"];
            options.Scope = configuration["AuthServer:Scope"];
            options.RequireHttps = configuration.GetValue<bool>("AuthServer:RequireHttpsMetadata");
        });
    }
}
