using Jh.Abp.JhPermission.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Jh.Abp.JhPermission.Blazor.Server.Host;

public abstract class JhPermissionComponentBase : AbpComponentBase
{
    protected JhPermissionComponentBase()
    {
        LocalizationResource = typeof(JhPermissionResource);
    }
}
