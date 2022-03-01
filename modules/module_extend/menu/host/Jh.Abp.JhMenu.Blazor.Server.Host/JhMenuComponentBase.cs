using Jh.Abp.JhMenu.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Jh.Abp.JhMenu.Blazor.Server.Host;

public abstract class JhMenuComponentBase : AbpComponentBase
{
    protected JhMenuComponentBase()
    {
        LocalizationResource = typeof(JhMenuResource);
    }
}
