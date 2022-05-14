using Jh.SourceGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using RazorEngine;
using RazorEngine.Templating; // For extension methods.
using Jh.SourceGenerator.Common.GeneratorDtos;
using Volo.Abp.Identity;
using Volo.Abp.AuditLogging;
using Volo.Abp.Domain.Entities;

namespace Jh.Abp.JhIdentity
{
    public class GeneratorServiceTest
    {
        [Fact]
        public void TestGetTableClass()
        {
            //模板路径为空不生成
            var basePathTemp = @"G:\Temp";
            var basePath = @"D:\github\mygithub\business\jhabpmodule\modules\identity";
            basePath = basePathTemp;
            var domainAssembly = typeof(JhIdentityDomainModule).Assembly;
            var domain = @"\Identity";
            var itemName = "Jh.Abp.JhIdentity";
            var options = new GeneratorOptions()
            {
                DbContext = "JhIdentityDbContext",
                Namespace = "Jh.Abp.JhIdentity",
                ControllerBase = "JhIdentityController",
                CreateContractsPermissionsPath = @$"{basePath}\src\{itemName}.Application.Contracts\Permissions",
                CreateContractsPath = @$"{basePath}\src\{itemName}.Application.Contracts{domain}",
                CreateApplicationPath = @$"{basePath}\src\{itemName}.Application{domain}",
                CreateDomainPath = @$"{basePath}\src\{itemName}.Domain{domain}",
                CreateEfCorePath = @$"{basePath}\src\{itemName}.EntityFrameworkCore{domain}",
                CreateHttpApiPath = @$"{basePath}\src\{itemName}.HttpApi\v1{domain}",
                CreateHtmlPath = @$"{basePathTemp}\host\{itemName}.Web.Unified\wwwroot\main\view",
                //CreateHtmlTemplatePath = @"G:\github\mygithub\jhabpmodule\modules\abpjh\src\GeneratorCoding\Jh.SourceGenerator.Common\CodeBuilders\Html\Layui"
                CreateHtmlTemplatePath = @"F:\github\mygithub\public\jh-abp-module-extension\modules\libs\GeneratorCoding\Jh.SourceGenerator.Common\CodeBuilders\Html\Layui"
            };
            var service = new GeneratorService(domainAssembly, options, GneratorType.AllField);
            //var mapTables = service.GetTableClassByGeneratorClass(typeof(Entity));
            Assert.True(service.GeneratorCode(new Type[] { typeof(IdentityUser),typeof(OrganizationUnit),typeof(IdentityRole) }));

            //var service = new GeneratorService(domainAssembly, options, GneratorType.AllField);
            //var mapTables = service.GetLoadableTypes().Where(cla => cla.IsClass && typeof(IAggregateRoot).IsAssignableFrom(cla)).ToArray();
            //Assert.True(service.GeneratorCode(new Type[] { typeof(MenuRoleMap) }));
        }
    }
}
