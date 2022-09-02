using Jh.Abp.TenantManagement;
using Jh.SourceGenerator.Common;
using Jh.SourceGenerator.Common.GeneratorDtos;
using System;
using Xunit;

namespace Jh.Abp.JhIdentity.JhSourceGeneratorCommon
{
    public class GeneratorService_Test
    {
        [Fact]
        public void ReactProxyServiceCodeBuilder_Test()
        {
            var moduleName = "JhIdentity";
            var moduleNamespace = $"API.{moduleName}";
            var generatorPath = @"G:\Temp";
            var service = new GeneratorService(new GeneratorOptions(generatorPath), GneratorType.AllField);
            //service.GeneratorCodeByAppService(moduleNamespace, "API", $"{moduleName}_API", new Type[] { typeof(TenantController) });
            //service.GeneratorCodeByTsx(moduleNamespace, new Type[] { typeof(TenantDto) }, moduleName);
        }
    }
}
