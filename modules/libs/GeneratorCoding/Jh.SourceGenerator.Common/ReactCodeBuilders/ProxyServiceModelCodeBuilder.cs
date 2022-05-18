using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Jh.Abp.Common;
using System.Linq;

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
            //ignore attribute
            var fields = ModelType.GetProperties().Where(a => !a.CustomAttributes.Any(a => a.AttributeType == typeof(Newtonsoft.Json.JsonIgnoreAttribute)));
            foreach (var field in fields)
            {
                var propertyType = field.PropertyType.GetRealType();
                var propertyTypeName = propertyType.Name.FormatJsVar(true);
                propertyTypeName = propertyType.NotJsType() ? "any" : propertyTypeName;
                //理论上前端不应该有domain的类，所以可以使用any类型
                //GeneratorHelper.AddProxyServiceModelCodeBuilder(propertyType);
                builder.AppendLine($"\t {field.Name.ToCamelCase(CamelCaseType.LowerCamelCase)}?: {propertyTypeName};");
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
