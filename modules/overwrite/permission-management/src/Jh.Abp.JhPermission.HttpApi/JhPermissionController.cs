using Jh.Abp.JhPermission.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Jh.Abp.JhPermission;

public abstract class JhPermissionController : AbpControllerBase
{
    protected JhPermissionController()
    {
        LocalizationResource = typeof(JhPermissionResource);
    }
}
