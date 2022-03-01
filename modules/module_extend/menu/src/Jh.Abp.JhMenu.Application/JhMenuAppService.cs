using Jh.Abp.JhMenu.Localization;
using Volo.Abp.Application.Services;

namespace Jh.Abp.JhMenu;

public abstract class JhMenuAppService : ApplicationService
{
    protected JhMenuAppService()
    {
        LocalizationResource = typeof(JhMenuResource);
        ObjectMapperContext = typeof(JhMenuApplicationModule);
    }
}
