using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace YourCompany.YourProjectName;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(YourProjectNameDomainSharedModule)
)]
public class YourProjectNameDomainModule : AbpModule
{

}
