using Jh.Abp.Application.Contracts;
using Jh.Abp.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Jh.Abp.Application
{
    [DependsOn(
    typeof(JhAbpDomainModule),
    typeof(JhAbpContractsModule),
    typeof(AbpDddApplicationModule)
    )]
    public class JhAbpApplicationModule:Volo.Abp.Modularity.AbpModule
    {
    }
}
