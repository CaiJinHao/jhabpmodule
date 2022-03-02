using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace YourCompany.YourProjectName;

[DependsOn(
    typeof(YourProjectNameApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class YourProjectNameHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(YourProjectNameApplicationContractsModule).Assembly,
            YourProjectNameRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<YourProjectNameHttpApiClientModule>();
        });

    }
}
