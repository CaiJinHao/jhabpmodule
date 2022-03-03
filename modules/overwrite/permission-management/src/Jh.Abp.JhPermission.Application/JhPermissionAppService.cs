using Jh.Abp.JhPermission.Localization;
using Volo.Abp.Application.Services;

namespace Jh.Abp.JhPermission;

public abstract class JhPermissionAppService : ApplicationService
{
    protected JhPermissionAppService()
    {
        LocalizationResource = typeof(JhPermissionResource);
        ObjectMapperContext = typeof(JhPermissionApplicationModule);
    }
}
