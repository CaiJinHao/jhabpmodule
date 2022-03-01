using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Jh.Abp.JhIdentity;

[Dependency(ReplaceServices = true)]
public class JhIdentityBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "JhIdentity";
}
