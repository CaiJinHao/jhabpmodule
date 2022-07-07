using Jh.Abp.AuditLogging;
using Jh.Abp.JhIdentity.v1;
using Jh.Abp.JhIdentity.v1.SettingManagement;
using Jh.Abp.JhIdentity.v1.TenantManagement;
using Jh.Abp.PermissionManagement;
using Jh.Abp.SettingManagement;
using Jh.SourceGenerator.Common;
using Jh.SourceGenerator.Common.GeneratorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging;
using Volo.Abp.Identity;
using Volo.Abp.TenantManagement;
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
            service.GeneratorCodeByAppService(moduleNamespace, "API", $"{moduleName}_API", new Type[] { typeof(TenantController) });
            service.GeneratorCodeByTsx(moduleNamespace, new Type[] { typeof(TenantDto) }, moduleName);
        }
    }
}
