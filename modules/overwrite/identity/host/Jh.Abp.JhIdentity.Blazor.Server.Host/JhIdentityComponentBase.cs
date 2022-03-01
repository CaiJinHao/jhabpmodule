using Jh.Abp.JhIdentity.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Jh.Abp.JhIdentity.Blazor.Server.Host;

public abstract class JhIdentityComponentBase : AbpComponentBase
{
    protected JhIdentityComponentBase()
    {
        LocalizationResource = typeof(JhIdentityResource);
    }
}
