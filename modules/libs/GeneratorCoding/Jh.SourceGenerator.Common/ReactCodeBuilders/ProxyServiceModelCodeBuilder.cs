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
        public ProxyServiceModelCodeBuilder(Type modelType, string filePath)
        {
            IsGenerator = true;
            ModelType = modelType;
            Suffix = ".ts";
            FilePath = filePath;
            FileName = $"mode.{modelType.Name.ToLower()}";
        }

        public override string ToString()
        {
            if (ModelType.Name == "String")
            {

            }
            if (ModelType.Name == "Object")
            {

            }
            var builder = new StringBuilder();
            builder.AppendLine($"export interface {ModelType.Name}");
            builder.AppendLine("{");
            var fields = ModelType.GetProperties();
            foreach (var field in fields)
            {
                var propertyType = field.PropertyType.GetRealType().Name
                    .GetTypeName($"({nameof(Double)})|({nameof(Decimal)})|({nameof(Int64)})|({nameof(Int32)})|({nameof(Int16)})", "number")
                    .GetTypeName($"{nameof(Guid)}","string")
                    .GetTypeName($"{nameof(DateTime)}","string")
                    .GetTypeName($"{nameof(DateTimeOffset)}","string")
                    ;

                builder.AppendLine($"\t {field.Name}?: {propertyType};");
            }
            builder.AppendLine("}");

            //处理类型嵌套
            return builder.ToString();
        }
    }
}
