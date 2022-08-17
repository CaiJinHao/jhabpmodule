using Jh.Abp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace Jh.Abp.MongoDB
{
    [DependsOn(
       typeof(JhAbpDomainModule),
        typeof(AbpMongoDbModule)
      )]
    public class JhAbpMongoDBModule : Volo.Abp.Modularity.AbpModule
    {
    }
}
