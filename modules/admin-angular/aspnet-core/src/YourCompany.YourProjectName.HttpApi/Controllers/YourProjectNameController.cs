using YourCompany.YourProjectName.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace YourCompany.YourProjectName.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class YourProjectNameController : AbpControllerBase
{
    protected YourProjectNameController()
    {
        LocalizationResource = typeof(YourProjectNameResource);
    }
}
