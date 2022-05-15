using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Jh.Abp.Common;

namespace Jh.SourceGenerator.Common
{
    public static class GeneratorHelper
    {
        private static Dictionary<string, ProxyServiceModelCodeBuilder> ProxyServiceModelCodeBuilders { get; set; }
        public static Dictionary<string, ProxyServiceModelCodeBuilder> GetProxyServiceModelCodeBuilders()
        { 
            return ProxyServiceModelCodeBuilders;
        }
        /// <summary>
        /// 目前是每生成一个service，初始化一次，目的：每个service的dto放在一起
        /// </summary>
        public static void InitialProxyServceModelCodeBuilders()
        {
            ProxyServiceModelCodeBuilders = new Dictionary<string, ProxyServiceModelCodeBuilder>();
        }

        public static bool IsModelType(this Type modelType)
        {
            var type = modelType.GetRealTypeValue();
            if (!type.IsValueType
                && type.BaseType != null
                && !new Regex($"({nameof(Task)})|({nameof(String)})").IsMatch(type.Name)//排除生成Model的类型
                )
            {
                return true;
            }
            return false;
        }

        public static void AddProxyServiceModelCodeBuilder(Type modelType)
        {
            var type = modelType.GetRealTypeValue();
            if (type.IsModelType())
            {
                if (!ProxyServiceModelCodeBuilders.ContainsKey(type.Name))
                {
                    ProxyServiceModelCodeBuilders.Add(type.Name, null);
                    ProxyServiceModelCodeBuilders[type.Name] = new ProxyServiceModelCodeBuilder(type);
                }
            }
        }

        /// <summary>
        /// 格式化为js的类型格式
        /// </summary>
        public static string FormatJsVar(this string input, bool isToLower = false)
        {
            var data = input
                    .GetTypeName($"({nameof(Double)})|({nameof(Decimal)})|({nameof(Int64)})|({nameof(Int32)})|({nameof(Int16)})", "number")
                    .GetTypeName($"{nameof(Guid)}", "string")
                    .GetTypeName($"{nameof(DateTimeOffset)}", "string")
                    .GetTypeName($"{nameof(DateTime)}", "string")
                    .GetTypeName($"{nameof(Object)}","any")
                    ;
            if (isToLower)
            {
                return data.ToCamelCase(CamelCaseType.LowerCamelCase);
            }
            return data;
        }

        /// <summary>
        /// 获取类型名称,如果是泛型自动使用泛型
        /// </summary>
        /// <param name="type"></param>
        /// <param name="globalNamespace">全局类型定义的命名空间 一般为API</param>
        /// <param name="moduleNamespace">模块定义的命名空间</param>
        /// <returns></returns>
        public static string GetReturnTypeName(this Type type,string moduleNamespace, string globalNamespace)
        {
            var genericTypeName = type.Name;
            if (type.IsModelType())
            {
                if (type.IsGenericType)
                {
                    genericTypeName = $"{globalNamespace}.{genericTypeName}";
                    var genericArgType = type.GenericTypeArguments.FirstOrDefault();
                    var genericArgTypeName = genericArgType.Name;
                    if (genericArgType.IsModelType())
                    {
                        genericArgTypeName = $"{moduleNamespace}.{genericArgTypeName}";
                    }
                    return genericTypeName.Replace("`1", $"<{genericArgTypeName}>");
                }
                else
                {
                    return $"{moduleNamespace}.{genericTypeName}";
                }
            }
            return genericTypeName.FormatJsVar();
        }
    }
}
