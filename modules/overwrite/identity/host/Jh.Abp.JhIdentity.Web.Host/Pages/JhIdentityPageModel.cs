using Jh.Abp.JhIdentity.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Jh.Abp.JhIdentity.Pages;

public abstract class JhIdentityPageModel : AbpPageModel
{
    protected JhIdentityPageModel()
    {
        LocalizationResourceType = typeof(JhIdentityResource);
    }
}
