﻿using Localization.Resources.AbpUi;
using Jh.Abp.JhMenu.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Jh.Abp.JhMenu;

[DependsOn(
    typeof(JhMenuApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class JhMenuHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(JhMenuHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<JhMenuResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
