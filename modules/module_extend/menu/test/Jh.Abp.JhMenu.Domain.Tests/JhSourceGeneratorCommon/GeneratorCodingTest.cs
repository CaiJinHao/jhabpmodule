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
using Volo.Abp.Domain.Entities;

namespace Jh.Abp.JhMenu
{
    public class GeneratorCodingTest
    {
        [Fact]
        public void TestGetTableClass()
        {
            //模板路径为空不生成
            var basePathTemp = @"G:\Temp";
            var basePath = @"D:\github\mygithub\business\jhabpmodule\modules\menu";
            basePath = basePathTemp;
            var domainAssembly = typeof(JhMenuDomainModule).Assembly;
            var itemName = "Jh.Abp.JhMenu";
            var domain = @"\JhMenu";
            var options = new GeneratorOptions()
            {
                DbContext = "JhMenuDbContext",
                Namespace = "Jh.Abp.JhMenu",
                ControllerBase = "JhMenuController",
                CreateContractsPermissionsPath = @$"{basePath}\src\{itemName}.Application.Contracts\Permissions",
                CreateContractsPath = @$"{basePath}\src\{itemName}.Application.Contracts{domain}",
                CreateApplicationPath = @$"{basePath}\src\{itemName}.Application{domain}",
                CreateDomainPath = @$"{basePath}\src\{itemName}.Domain{domain}",
                CreateEfCorePath = @$"{basePath}\src\{itemName}.EntityFrameworkCore{domain}",
                CreateHttpApiPath = @$"{basePath}\src\{itemName}.HttpApi\v1{domain}",
                //不需要domain做文件夹
                CreateHtmlPath = @$"{basePathTemp}\host\{itemName}.HttpApi.Host\wwwroot\main\view",
                CreateHtmlTemplatePath = @"G:\github\mygithub\jh-abp-module-extension\modules\libs\GeneratorCoding\Jh.SourceGenerator.Common\CodeBuilders\Html\Layui"
            };
            var service = new GeneratorService(domainAssembly, options);
            var mapTables = service.GetTableClassByGeneratorClass(typeof(IEntity));
            Assert.True(service.GeneratorCode(mapTables));

            //var service = new GeneratorService(domainAssembly, options, GneratorType.AllField);
            //var mapTables = service.GetLoadableTypes().Where(cla => cla.IsClass && typeof(IAggregateRoot).IsAssignableFrom(cla)).ToArray();
            //Assert.True(service.GeneratorCode(new Type[] { typeof(MenuRoleMap) }));
        }
    }
}
