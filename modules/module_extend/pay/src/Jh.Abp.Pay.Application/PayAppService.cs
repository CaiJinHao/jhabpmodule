using Jh.Abp.Pay.Localization;
using Volo.Abp.Application.Services;

namespace Jh.Abp.Pay;

public abstract class PayAppService : ApplicationService
{
    protected PayAppService()
    {
        LocalizationResource = typeof(PayResource);
        ObjectMapperContext = typeof(PayApplicationModule);
    }
}
