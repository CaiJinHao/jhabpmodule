using Jh.Abp.JhIdentity.Localization;
using Volo.Abp.Application.Services;

namespace Jh.Abp.JhIdentity;

public abstract class JhIdentityAppService : ApplicationService
{
    protected JhIdentityAppService()
    {
        LocalizationResource = typeof(JhIdentityResource);
        ObjectMapperContext = typeof(JhIdentityApplicationModule);
    }
}
