using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Jh.Abp.JhIdentity;

[DependsOn(
    typeof(JhIdentityApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class JhIdentityHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(JhIdentityApplicationContractsModule).Assembly,
            JhIdentityRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<JhIdentityHttpApiClientModule>();
        });

    }
}
