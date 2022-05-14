using Jh.Abp.Common;
using Jh.SourceGenerator.Common.ReactCodeBuilders;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jh.SourceGenerator.Common
{
    public class ProxyServiceCodeBuilder: CodeBuilderBase
    {
        private const string RouteAttribute = "RouteAttribute";
        private const string HttpMethodAttribute = "HttpMethodAttribute";
        private const string MapToApiVersionAttribute = "MapToApiVersionAttribute";
        private Type ControllerType { get; }
        protected ControllerDto ControllerDto { get; set; } 
        protected string TemplateFilePath { get; set; }
        public ProxyServiceCodeBuilder(Type controllerType, string filePath,string templateFilePath)
        {
            ControllerType = controllerType;
            Suffix = ".ts";
            FilePath = filePath;
            TemplateFilePath = templateFilePath;
            ControllerDto = new ControllerDto(controllerType.Name.Replace("Controller",""));
            FileName = $"{ControllerDto.Name.ToLower()}.service";
            InitPropertys();
        }

        private void InitPropertys()
        {
            var controllerRouteArg = ControllerType.CustomAttributes.FirstOrDefault(a => a.AttributeType.Name == RouteAttribute)
                ?.ConstructorArguments.FirstOrDefault();
            if (controllerRouteArg == null)
            {
                return;
            }
            var methods = ControllerType.GetMethods().Where(a => a.IsPublic && a.DeclaringType == ControllerType).ToList();
            foreach (var item in methods)
            {
                //方法必须包含http谓词
                var httpAttributes = item.CustomAttributes.Where(a => a.AttributeType.BaseType.Name == HttpMethodAttribute);
                if (httpAttributes.Any())
                {
                    var returnType = item.ReturnType.GetRealType();
                    GeneratorHelper.AddProxyServiceModelCodeBuilder(returnType);
                    var methodDto = new MethodDto()
                    {
                        Name = item.Name,
                        ReturnType = returnType.Name,
                        RequestMethod = httpAttributes.First().AttributeType.Name.Replace("Attribute",""),
                    };
                    foreach (var parameterInfo in item.GetParameters())
                    {
                        GeneratorHelper.AddProxyServiceModelCodeBuilder(parameterInfo.ParameterType);
                        methodDto.Parameters.Add(parameterInfo.Name,parameterInfo.ParameterType.Name);
                    }
                    //方法的版本
                    var apiVersionAttrbuteArg = item.CustomAttributes.LastOrDefault(a => a.AttributeType.Name == MapToApiVersionAttribute)?.ConstructorArguments.FirstOrDefault();
                    var apiVersion = apiVersionAttrbuteArg == null ? "1" : apiVersionAttrbuteArg.Value.ToString().Trim('"');
                    var controllerRouteUrl = controllerRouteArg.Value.ToString().Trim('"')
                        .Replace("[controller]", ControllerDto.Name)
                        .Replace("{apiVersion:apiVersion}", apiVersion)
                        ;
                    var methodRouteAttrbuteArg = item.CustomAttributes.FirstOrDefault(a => a.AttributeType.Name == RouteAttribute)?.ConstructorArguments.FirstOrDefault();
                    var methodRouteUrl = methodRouteAttrbuteArg == null ? "" : $"/{methodRouteAttrbuteArg.Value.ToString().Trim('"')}";
                    methodDto.RouteUrl = $"{controllerRouteUrl}{methodRouteUrl}";
                    ControllerDto.MethodDtos.Add(methodDto);
                }
            }
        }

        public override string ToString()
        {
            string razorTemplateContent = TemplateFilePath.ReadFile();
            return Engine.Razor.RunCompile(razorTemplateContent, FileName, null, ControllerDto);
        }
    }
}
