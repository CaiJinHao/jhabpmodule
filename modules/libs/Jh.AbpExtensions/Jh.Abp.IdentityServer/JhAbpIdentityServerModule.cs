using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Volo.Abp;
using Volo.Abp.Application;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Authorization;
using Volo.Abp.IdentityServer.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.MultiTenancy.ConfigurationStore;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Jh.Abp.IdentityServer
{
    [DependsOn(
        typeof(AbpMultiTenancyModule)
        ,typeof(AbpAspNetCoreMultiTenancyModule)
        )]
    public class JhAbpIdentityServerModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<JhAbpIdentityServerModule>(typeof(JhAbpIdentityServerModule).Namespace);
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<JhAbpIdentityServerResource>("zh-Hans")
                    .AddBaseTypes(typeof(AbpIdentityServerResource))
                    //模块资源按照项目名称+文件夹路径写
                    .AddVirtualJson("/Localization/JhAbpIdentityServer");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("JhAbpIdentityServer", typeof(JhAbpIdentityServerResource));
            });

            context.Services.AddTransient<JhAbpClaimsPrincipalContributor>();

            //全局样式
            Configure<AbpBundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    .Configure(ThemeBundles.Styles.Login, bundle =>
                    {
                        bundle.AddContributors(typeof(LoginGlobalStyleContributor));
                    })
                    .Configure(ThemeBundles.Styles.Register, bundle =>
                    {
                        bundle.AddContributors(typeof(RegisterGlobalStyleContributor));
                    })
                    ;

                options
                .ScriptBundles
                .Configure(ThemeBundles.Scripts.Register, bundle =>
                {
                    bundle.AddContributors(typeof(RegisterGlobalScriptContributor));
                });
            });
        }
    }
}
