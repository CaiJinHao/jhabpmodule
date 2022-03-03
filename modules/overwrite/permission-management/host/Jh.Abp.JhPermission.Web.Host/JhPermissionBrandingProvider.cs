using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Jh.Abp.JhPermission;

[Dependency(ReplaceServices = true)]
public class JhPermissionBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "JhPermission";
}
