using YourCompany.YourProjectName.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace YourCompany.YourProjectName;

public abstract class YourProjectNameController : AbpControllerBase
{
    protected YourProjectNameController()
    {
        LocalizationResource = typeof(YourProjectNameResource);
    }
}
