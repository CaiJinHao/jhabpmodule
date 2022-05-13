using Jh.Abp.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Jh.Abp.Common
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// 获取类型枚举
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ObjectType GetObjectType(this Type type)
        {
            ObjectType value;
            if (type.IsEnum)
            {
                return ObjectType.Enum;
            }
            Enum.TryParse(type.Name, out value);
            return value;
        }

        public static IEnumerable<TSource> ToNullList<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                return new List<TSource>();
            }
            return source;
        }

        public static string ToDescription(this Enum value)
        {
            var result = string.Empty;
            if (value == null)
            {
                return result;
            }
            var _filed = value.GetType().GetFields().FirstOrDefault(a => a.Name == value.ToString());
            if (_filed != null)
            {
                var arguments = _filed.CustomAttributes
                        .Where(a => a.AttributeType == typeof(DescriptionAttribute)).FirstOrDefault()?.ConstructorArguments;
                if (arguments == null)
                {
                    return string.Empty;
                }
                result = arguments.First().Value.ToString();
            }
            return result;
        }

        /// <summary>
        /// 针对泛型需要获取真实 类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type GetRealType(this Type type)
        {
            return type.IsGenericType? type.GenericTypeArguments.FirstOrDefault() : type;
        }

        /// <summary>
        /// 只要类型，不要数组类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type GetRealTypeValue(this Type type)
        {
            var result= type.IsGenericType ? type.GenericTypeArguments.FirstOrDefault() : type;
            if (result.IsArray)
            {
                result= Type.GetType(result.FullName.Replace("[]", ""));
            }
            return result;
        }

        public static string GetTypeName(this string input, string regexStr, string replaceTypeName)
        {
            var regex = new System.Text.RegularExpressions.Regex(regexStr);
            if (regex.IsMatch(input))
            {
                return regex.Replace(input, replaceTypeName);//为什么是替换，因为可能是数组
            }
            return input;
        }
    }
}
