using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Jh.Abp.Domain
{
    [DependsOn(
        typeof(AbpDddDomainModule)
    )]
    public class JhAbpDomainModule:Volo.Abp.Modularity.AbpModule
    {
    }
}
