using Volo.Abp.Studio;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace YourCompany.YourProjectName;

[DependsOn(
    typeof(AbpStudioModuleInstallerModule),
    typeof(AbpVirtualFileSystemModule)
    )]
public class YourProjectNameInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<YourProjectNameInstallerModule>();
        });
    }
}
