using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Jh.Abp.Common;

namespace Jh.SourceGenerator.Common
{
    public class ProxyServiceModelCodeBuilder : CodeBuilderBase
    {
        public Type ModelType { get; }
        private bool IsGenerator { get; }
        private StringBuilder StringBuilder { get; set; }
        public ProxyServiceModelCodeBuilder(Type modelType)
        {
            IsGenerator = true;
            ModelType = modelType;
            Suffix = ".ts";
            FileName = $"mode.{modelType.Name.ToLower()}";
            InitStringBuilder();
        }

        public void InitStringBuilder()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"export interface {ModelType.Name}");
            builder.AppendLine("{");
            var fields = ModelType.GetProperties();
            foreach (var field in fields)
            {
                var propertyType = field.PropertyType.GetRealType();
                var propertyTypeName = propertyType.Name
                    .GetTypeName($"({nameof(Double)})|({nameof(Decimal)})|({nameof(Int64)})|({nameof(Int32)})|({nameof(Int16)})", "number")
                    .GetTypeName($"{nameof(Guid)}", "string")
                    .GetTypeName($"{nameof(DateTimeOffset)}", "string")
                    .GetTypeName($"{nameof(DateTime)}", "string")
                    ;
                propertyTypeName = GeneratorHelper.IsModelType(propertyType) ? "any" : propertyTypeName;
                //GeneratorHelper.AddProxyServiceModelCodeBuilder(propertyType);//理论上前端不应该有domain的类，所以可以使用any类型
                builder.AppendLine($"\t {field.Name}?: {propertyTypeName};");
            }
            builder.AppendLine("}");
            StringBuilder = builder;
        }

        public override string ToString()
        {
            return StringBuilder.ToString();
        }
    }
}
