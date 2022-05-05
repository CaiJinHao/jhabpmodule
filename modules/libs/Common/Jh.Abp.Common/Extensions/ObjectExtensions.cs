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
                if (arguments==null)
                {
                    return string.Empty;
                }
                result = arguments.First().Value.ToString();
            }
            return result;
        }
    }
}
