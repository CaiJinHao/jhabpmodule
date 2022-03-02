using YourCompany.YourProjectName.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace YourCompany.YourProjectName.Pages;

public abstract class YourProjectNamePageModel : AbpPageModel
{
    protected YourProjectNamePageModel()
    {
        LocalizationResourceType = typeof(YourProjectNameResource);
    }
}
