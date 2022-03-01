using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Jh.Abp.JhMenu;

[DependsOn(
    typeof(JhMenuApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class JhMenuHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(JhMenuApplicationContractsModule).Assembly,
            JhMenuRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<JhMenuHttpApiClientModule>();
        });

    }
}
