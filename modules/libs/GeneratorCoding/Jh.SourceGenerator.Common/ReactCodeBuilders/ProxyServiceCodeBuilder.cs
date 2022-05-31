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
        protected string ProxyName { get; }
        public ProxyServiceCodeBuilder(Type controllerType, string filePath,string moduleNamespace,string globalNamespace,string proxyName)
        {
            ProxyName = proxyName;
            ControllerDto = new ControllerDto(controllerType.Name.Replace("Controller",""), moduleNamespace,globalNamespace);
            ControllerType = controllerType;
            Suffix = ".ts";
            if (!string.IsNullOrEmpty(filePath))
            {
                FilePath = Path.Combine(filePath, $"services/{ControllerDto.Name}");//以表名称为上级文件名创建路径
            }
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
                    GeneratorHelper.AddProxyServiceModelCodeBuilder(item.ReturnType);
                    var methodDto = new MethodDto()
                    {
                        Name = item.Name,
                        ReturnType = item.ReturnType.GetTypeName(ControllerDto.ModuleNamespace, ControllerDto.GlobalNamespace),
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
            var stringBuilder=new System.Text.StringBuilder();
            stringBuilder.AppendLine("import { request } from 'umi';");
            foreach (var method in ControllerDto.MethodDtos)
            {
                var methodName = method.Name.Replace("Async", "");
                var parameterName = method.GetParameterKeys();
                if (methodName.StartsWith("Delete"))
                {
                    methodName = $"DeleteBy{method.Parameters.First().Key.ToCamelCase(CamelCaseType.UpperCamelCase)}";
                }
                else if (methodName.StartsWith("Update")) {
                    parameterName = method.Parameters.Last().Key;
                }
                method.RouteUrl = new System.Text.RegularExpressions.Regex(@"{").Replace(method.RouteUrl, "${");//给参数添加js语法 字符串插值
                stringBuilder.AppendLine($"export const {methodName} = async ({method.GetParameters(ControllerDto.ModuleNamespace)}): Promise<{method.ReturnType}> => {{");
                if (methodName.Equals("Create")) {
                    stringBuilder.AppendLine("if (!input.extraProperties) { input.extraProperties = {}; }");
                }
                stringBuilder.AppendLine($"  return await request<{method.ReturnType}>(`${{{ProxyName}}}{method.RouteUrl}`, {{");
                var requestMethod = method.RequestMethod.Replace("Http", "");
                stringBuilder.AppendLine($"    method: '{requestMethod}',");
                //判断参数是不是已经在路由中包含了
                if (!new System.Text.RegularExpressions.Regex($"{{{parameterName}}}").IsMatch(method.RouteUrl))
                {
                    if (method.Parameters.Count > 0 )
                    {
                        if (requestMethod.ToLower() != "get")
                        {
                            stringBuilder.AppendLine($"data: {parameterName}");
                        }
                        else
                        {
                            //判断参数是对象不是
                            if (method.Parameters.First().Value.NotJsType())
                            {
                                stringBuilder.AppendLine($"params: {parameterName}");
                            }
                            else
                            {
                                stringBuilder.AppendLine($"params: {{{parameterName}}}");
                            }
                        }
                    }
                }
                stringBuilder.AppendLine("  });");
                stringBuilder.AppendLine("};");
            }

            return stringBuilder.ToString();
        }
    }
}
