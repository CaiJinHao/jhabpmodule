using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Jh.Abp.Common.Utils
{
    public class UtilEnums
    {
        /// <summary>
        /// 获取所有枚举列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<dynamic> GetEnumList<T>() where T : Enum
        {
            var values = Enum.GetValues(typeof(T));
            foreach (var item in values)
            {
                yield return new OptionDto<int>()
                {
                    Text = item.ToString(),
                    Value = (int)item
                };
            }
        }

        /// <summary>
        /// 获取枚举列表 没有特性的枚举不返回
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<dynamic> GetEnumListByDescription<T>() where T : Enum
        {
            var fileds = typeof(T).GetFields().Where(a => a.FieldType == typeof(T));
            foreach (var _filed in fileds)
            {
                var _v = _filed.GetValue(_filed.Name);
                if (_filed.CustomAttributes.Count() > 0)
                {
                    var arguments = _filed.CustomAttributes
                    .Where(a => a.AttributeType == typeof(DescriptionAttribute)).FirstOrDefault()?.ConstructorArguments;
                    yield return new OptionDto<int>()
                    {
                        Text = arguments.First().Value.ToString(),
                        Value = (int)_v
                    };
                }
                //没有特性的枚举不返回
                //else
                //{
                //    yield return new
                //    {
                //        Text = _filed.Name,
                //        Value = (int)_v
                //    };
                //}
            }
        }

        public static string GetEnumValueDescription<T>(T name) where T : Enum
        {
            var _filed = typeof(T).GetFields().FirstOrDefault(a => a.Name == name.ToString());
            if (_filed.CustomAttributes.Count() > 0)
            {
                var arguments = _filed.CustomAttributes
                .Where(a => a.AttributeType == typeof(DescriptionAttribute)).FirstOrDefault()?.ConstructorArguments;
                return arguments.First().Value.ToString();
            }
            return string.Empty;
        }
    }
}
