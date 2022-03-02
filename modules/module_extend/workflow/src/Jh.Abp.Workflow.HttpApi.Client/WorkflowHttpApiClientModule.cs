using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Jh.Abp.Workflow;

[DependsOn(
    typeof(WorkflowApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class WorkflowHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(WorkflowApplicationContractsModule).Assembly,
            WorkflowRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<WorkflowHttpApiClientModule>();
        });

    }
}
