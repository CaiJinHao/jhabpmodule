using YourCompany.YourProjectName.Localization;
using Volo.Abp.AspNetCore.Components;

namespace YourCompany.YourProjectName.Blazor.Server.Host;

public abstract class YourProjectNameComponentBase : AbpComponentBase
{
    protected YourProjectNameComponentBase()
    {
        LocalizationResource = typeof(YourProjectNameResource);
    }
}
