#nullable enable

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.ComponentModel;

namespace Jh.Abp.Common.Json.Converters
{
    public class JhStringEnumConverter : StringEnumConverter
    {
        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                writer.WriteNull();
                return;
            }

            var _filed = value.GetType().GetFields().FirstOrDefault(a => a.Name == value.ToString());
            if (_filed != null)
            {
                var arguments = _filed.CustomAttributes
                        .Where(a => a.AttributeType == typeof(DescriptionAttribute)).FirstOrDefault()?.ConstructorArguments;
                value = arguments.First().Value;
            }
            writer.WriteValue(value);
        }
    }
}
