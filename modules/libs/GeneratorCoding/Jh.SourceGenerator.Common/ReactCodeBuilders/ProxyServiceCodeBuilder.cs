using Jh.Abp.Common;
using Jh.SourceGenerator.Common.ReactCodeBuilders;
using RazorEngine;
using RazorEngine.Templating;
using System;
using System.Collections.Generic;
using System.IO;
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
        protected string ProxyName { get; }
        public ProxyServiceCodeBuilder(Type controllerType, string filePath,string templateFilePath,string moduleNamespace,string globalNamespace,string proxyName)
        {
            ProxyName = proxyName;
            ControllerDto = new ControllerDto(controllerType.Name.Replace("Controller",""), moduleNamespace,globalNamespace);
            ControllerType = controllerType;
            Suffix = ".ts";
            if (!string.IsNullOrEmpty(filePath))
            {
                FilePath = Path.Combine(filePath, ControllerDto.Name);//以表名称为上级文件名创建路径
            }
            TemplateFilePath = templateFilePath;
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
                        ReturnType = returnType.GetReturnTypeName(ControllerDto.ModuleNamespace, ControllerDto.GlobalNamespace),
                        RequestMethod = httpAttributes.First().AttributeType.Name.Replace("Attribute",""),
                    };
                    foreach (var parameterInfo in item.GetParameters())
                    {
                        GeneratorHelper.AddProxyServiceModelCodeBuilder(parameterInfo.ParameterType);
                        methodDto.Parameters.Add(parameterInfo.Name,parameterInfo.ParameterType);
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
            //string razorTemplateContent = TemplateFilePath.ReadFile();
            //return Engine.Razor.RunCompile(razorTemplateContent, FileName, null, ControllerDto);

            var stringBuilder=new System.Text.StringBuilder();
            stringBuilder.AppendLine("import { request } from 'umi';");
            foreach (var method in ControllerDto.MethodDtos)
            {
                var returnType = method.ReturnType;
                switch (method.ReturnType)
                {
                    case "Task": { returnType = "void"; } break;
                }
                stringBuilder.AppendLine($"export const {method.Name}{ControllerDto.Name} = async ({method.GetParameters(ControllerDto.ModuleNamespace)}): Promise<{returnType}> => {{");
                stringBuilder.AppendLine($"  return await request<{returnType}>(`${{{ProxyName}}}{method.RouteUrl}`, {{");
                stringBuilder.AppendLine($"    method: '{method.RequestMethod.Replace("Http", "")}',");
                stringBuilder.AppendLine(method.Parameters.Count > 0 ? $"data: {method.GetParameterKeys()}" : "");
                stringBuilder.AppendLine("  });");
                stringBuilder.AppendLine("};");
            }

            return stringBuilder.ToString();
        }
    }
}
