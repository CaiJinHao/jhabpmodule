using Jh.Abp.JhIdentity.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Jh.Abp.JhIdentity;

/* ApiController 必须的，用于添加版本控制 */
[ApiController]
public abstract class JhIdentityController : AbpControllerBase
{
    protected JhIdentityController()
    {
        LocalizationResource = typeof(JhIdentityResource);
    }
}
