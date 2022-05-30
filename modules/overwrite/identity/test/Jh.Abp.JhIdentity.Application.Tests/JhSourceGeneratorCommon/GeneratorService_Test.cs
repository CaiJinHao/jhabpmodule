using Jh.Abp.JhIdentity.v1;
using Jh.SourceGenerator.Common;
using Jh.SourceGenerator.Common.GeneratorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Xunit;

namespace Jh.Abp.JhIdentity.JhSourceGeneratorCommon
{
    public class GeneratorService_Test
    {
        [Fact]
        public void ReactProxyServiceCodeBuilder_Test()
        {
            var moduleNamespace = "API.JhIdentity";
            var generatorPath = @"G:\Temp";
            var service = new GeneratorService(new GeneratorOptions(generatorPath));
            service.GeneratorCodeByAppService(moduleNamespace, "API", "Identity_API", new Type[] { typeof(IdentityRoleController) });
            service.GeneratorCodeByTsx(moduleNamespace, new Type[] { typeof(IdentityRole) }, "JhIdentity");
        }
    }
}
