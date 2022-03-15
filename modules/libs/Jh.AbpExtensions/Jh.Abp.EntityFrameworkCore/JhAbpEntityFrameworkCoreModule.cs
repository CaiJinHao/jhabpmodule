using Jh.Abp.Domain;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Jh.Abp.EntityFrameworkCore
{
    [DependsOn(
        typeof(JhAbpDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
       )]
    public class JhAbpEntityFrameworkCoreModule : Volo.Abp.Modularity.AbpModule
    {
    }
}
