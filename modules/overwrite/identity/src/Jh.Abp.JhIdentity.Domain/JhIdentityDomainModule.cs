using Volo.Abp.AuditLogging;
using Volo.Abp.Domain;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;

namespace Jh.Abp.JhIdentity;

[DependsOn(
    typeof(AbpSettingManagementDomainModule),
    typeof(AbpDddDomainModule),
    typeof(AbpAuditLoggingDomainModule),
    typeof(AbpIdentityDomainModule),
    typeof(JhIdentityDomainSharedModule)
)]
public class JhIdentityDomainModule : AbpModule
{

}
