using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Jh.Abp.JhPermission.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class JhPermissionBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "JhPermission";
}
