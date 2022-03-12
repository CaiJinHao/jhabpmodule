using Jh.Abp.Application.Contracts;
using Jh.Abp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Jh.Abp.EntityFrameworkCore
{
    [DependsOn(
        typeof(JhAbpDomainModule),
        typeof(JhAbpContractsModule),
        typeof(AbpEntityFrameworkCoreModule)
       )]
    public class JhAbpEntityFrameworkCoreModule : Volo.Abp.Modularity.AbpModule
    {
    }
}
