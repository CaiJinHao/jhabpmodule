using YourCompany.YourProjectName.Localization;
using Volo.Abp.Application.Services;

namespace YourCompany.YourProjectName;

public abstract class YourProjectNameAppService : ApplicationService
{
    protected YourProjectNameAppService()
    {
        LocalizationResource = typeof(YourProjectNameResource);
        ObjectMapperContext = typeof(YourProjectNameApplicationModule);
    }
}
