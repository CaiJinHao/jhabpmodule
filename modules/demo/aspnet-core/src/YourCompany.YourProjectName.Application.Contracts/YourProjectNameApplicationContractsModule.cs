using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace YourCompany.YourProjectName;

[DependsOn(
    typeof(YourProjectNameDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class YourProjectNameApplicationContractsModule : AbpModule
{

}
