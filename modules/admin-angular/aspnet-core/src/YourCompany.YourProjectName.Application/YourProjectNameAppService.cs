using System;
using System.Collections.Generic;
using System.Text;
using YourCompany.YourProjectName.Localization;
using Volo.Abp.Application.Services;

namespace YourCompany.YourProjectName;

/* Inherit your application services from this class.
 */
public abstract class YourProjectNameAppService : ApplicationService
{
    protected YourProjectNameAppService()
    {
        LocalizationResource = typeof(YourProjectNameResource);
    }
}
