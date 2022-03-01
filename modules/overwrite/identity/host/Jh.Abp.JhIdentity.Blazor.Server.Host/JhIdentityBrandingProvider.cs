using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Jh.Abp.JhIdentity.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class JhIdentityBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "JhIdentity";
}
