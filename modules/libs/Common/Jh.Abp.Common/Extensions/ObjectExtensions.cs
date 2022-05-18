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
        /// 获取真实类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type GetRealType(this Type type)
        {
            var resultType= type.IsGenericType ? type.GenericTypeArguments.FirstOrDefault() : type;
            if (resultType.IsArray)
            {
                resultType = Type.GetType(resultType.FullName.Replace("[]", ""));
            }
            if (resultType.IsGenericType)
            {
                return GetRealType(resultType);
            }
            return resultType;
        }

        /// <summary>
        /// 将匹配到的类型名，替换为指定的类型名
        /// </summary>
        /// <param name="input"></param>
        /// <param name="regexStr"></param>
        /// <param name="replaceTypeName"></param>
        /// <returns></returns>
        public static string GetTypeName(this string input, string regexStr, string replaceTypeName)
        {
            var regex = new System.Text.RegularExpressions.Regex(regexStr);
            if (regex.IsMatch(input))
            {
                return regex.Replace(input, replaceTypeName);//为什么是替换，因为可能是数组
            }
            return input;
        }

        /// <summary>
        /// 将开头字母转为小写
        /// </summary>
        public static string ToCamelCase(this string input, CamelCaseType camelCaseType)
        {
            var inputArray = input.ToArray();
            var first = inputArray.First().ToString();
            switch (camelCaseType)
            {
                case CamelCaseType.UpperCamelCase:
                    first = first.ToUpper();
                    break;
                default:
                    first = first.ToLower();
                    break;
            }
            return $"{first}{new string(inputArray.Skip(1).ToArray())}";
        }
    }

    public enum CamelCaseType
    {
        /// <summary>
        /// 开头字母小写
        /// </summary>
        LowerCamelCase,
        /// <summary>
        /// 开头字母大写
        /// </summary>
        UpperCamelCase
    }
}
