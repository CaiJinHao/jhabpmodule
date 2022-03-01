using Jh.Abp.JhMenu.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Jh.Abp.JhMenu;

public abstract class JhMenuController : AbpControllerBase
{
    protected JhMenuController()
    {
        LocalizationResource = typeof(JhMenuResource);
    }
}
