using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Jh.Abp.JhPermission;

[DependsOn(
    typeof(JhPermissionApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class JhPermissionHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(JhPermissionApplicationContractsModule).Assembly,
            JhPermissionRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<JhPermissionHttpApiClientModule>();
        });

    }
}
