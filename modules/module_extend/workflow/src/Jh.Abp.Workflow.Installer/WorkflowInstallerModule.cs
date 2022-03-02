using Volo.Abp.Studio;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Jh.Abp.Workflow;

[DependsOn(
    typeof(AbpStudioModuleInstallerModule),
    typeof(AbpVirtualFileSystemModule)
    )]
public class WorkflowInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<WorkflowInstallerModule>();
        });
    }
}
