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

        /// <summary>
        /// 判断类型是否为js类型对象
        /// </summary>
        /// <param name="modelType"></param>
        /// <returns></returns>
        public static bool NotJsType(this Type modelType)
        {
            if (!modelType.IsValueType
                && modelType.BaseType != null
                //正则不能换行
                && !new Regex($"({nameof(Double)})|({nameof(Decimal)})|({nameof(Int64)})|({nameof(Int32)})|({nameof(Int16)})|({nameof(Guid)})|({nameof(DateTimeOffset)})|({nameof(DateTime)})|({nameof(String)})|({nameof(Object)})|({nameof(Task)})")
                .IsMatch(modelType.Name)//排除生成Model的类型
                )
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 不会添加泛型，只会添加泛型内的类型
        /// </summary>
        /// <param name="modelType"></param>
        public static void AddProxyServiceModelCodeBuilder(Type modelType)
        {
            var type = modelType.GetRealType();
            if (type.NotJsType())
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
                    .GetTypeName($"{nameof(Guid)}|{nameof(DateTimeOffset)}|{nameof(DateTime)}|{nameof(String)}", "string")
                    .GetTypeName($"{nameof(Object)}","any")
                    .GetTypeName($"{nameof(Task)}","void")
                    ;
            if (isToLower)
            {
                return data.ToCamelCase(CamelCaseType.LowerCamelCase);
            }
            return data;
        }

        public static string GetTypeName(this Type type, string moduleNamespace, string globalNamespace)
        {
            if (!type.NotJsType() && type.IsGenericType)
            {
                return GetTypeName(type.GenericTypeArguments.FirstOrDefault(), moduleNamespace, globalNamespace);
            }
            //是js类型或者泛型类型
            if (type.NotJsType())
            {
                var typeName = type.Name;
                if (type.IsGenericType)
                {
                    typeName = $"{globalNamespace}.{typeName}";
                    var genericArgType = type.GenericTypeArguments.FirstOrDefault();
                    return typeName.Replace("`1", $"<{GetTypeName(genericArgType, moduleNamespace, globalNamespace)}>");
                }
                return $"{moduleNamespace}.{typeName}";
            }
            return type.Name.FormatJsVar();
        }
    }
}
