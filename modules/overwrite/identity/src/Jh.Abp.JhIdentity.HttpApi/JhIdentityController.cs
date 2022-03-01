using Jh.Abp.JhIdentity.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Jh.Abp.JhIdentity;

public abstract class JhIdentityController : AbpControllerBase
{
    protected JhIdentityController()
    {
        LocalizationResource = typeof(JhIdentityResource);
    }
}
