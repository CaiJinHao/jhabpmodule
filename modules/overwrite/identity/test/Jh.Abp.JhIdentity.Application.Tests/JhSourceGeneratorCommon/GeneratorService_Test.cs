using Jh.Abp.JhIdentity.v1;
using Jh.SourceGenerator.Common;
using Jh.SourceGenerator.Common.GeneratorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Jh.Abp.JhIdentity.JhSourceGeneratorCommon
{
    public class GeneratorService_Test
    {
        [Fact]
        public void ReactProxyServiceCodeBuilder_Test()
        {
            var templateFilePath = @"G:\github\mygithub\jhmodule\modules\libs\GeneratorCoding\Jh.SourceGenerator.Common\CodeBuilderTemplate\ReactProxyService.cshtml";
            var generatorPath = @"G:\Temp";
            var service = new GeneratorService(new GeneratorOptions(generatorPath));
            service.GeneratorCodeByAppService(templateFilePath,new Type[] { typeof(OrganizationUnitController) });
        }
    }
}
