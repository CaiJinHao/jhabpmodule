using Jh.SourceGenerator.Common.GeneratorDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Jh.SourceGenerator.Common.CodeBuilders
{
    public class PermissionsDefinitionProviderCodeBuilder : CodeBuilderAbs
    {
        public PermissionsDefinitionProviderCodeBuilder(IEnumerable<TableDto> tableDto, string filePath) : base(tableDto, filePath)
        {
            this.FileName = $"{Domain}PermissionDefinitionProvider";
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(@"
using System;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;");
            builder.AppendLine($"using {table.Namespace}.Localization;");

            builder.AppendLine($"namespace {table.Namespace}");
            builder.AppendLine("{");
            {
                builder.AppendLine($"\tpublic class {FileName}: PermissionDefinitionProvider");
                builder.AppendLine("\t{");
                {
                    var permissions = PermissionsName;
                    builder.AppendLine($"\tpublic override void Define(IPermissionDefinitionContext context)");
                    builder.AppendLine("\t{");
                    {
                        builder.AppendLine($"\t\tvar {Domain}Group = context.AddGroup({permissions}.GroupName, L(\"Permission:{Domain}\"));");
                        foreach (var item in tables)
                        {
                            var _moduleName = $"{item.Name}s";
                            builder.AppendLine($"\t\t  var {_moduleName}Permission = {Domain}Group.AddPermission({permissions}.{_moduleName}.Default, L(\"Permission:{_moduleName}\"));");
                            builder.AppendLine($"\t\t {_moduleName}Permission.AddChild({permissions}.{_moduleName}.Detail, L(\"Permission:Detail\"));");
                            builder.AppendLine($"\t\t {_moduleName}Permission.AddChild({permissions}.{_moduleName}.Create, L(\"Permission:Create\"));");
                            builder.AppendLine($"\t\t {_moduleName}Permission.AddChild({permissions}.{_moduleName}.Update, L(\"Permission:Edit\"));");
                            builder.AppendLine($"\t\t {_moduleName}Permission.AddChild({permissions}.{_moduleName}.Delete, L(\"Permission:Delete\"));");
                            builder.AppendLine($"\t\t {_moduleName}Permission.AddChild({permissions}.{_moduleName}.BatchDelete, L(\"Permission:BatchDelete\"));");
                            builder.AppendLine($"\t\t {_moduleName}Permission.AddChild({permissions}.{_moduleName}.Recover, L(\"Permission:Recover\"));");
                            builder.AppendLine($"\t\t {_moduleName}Permission.AddChild({permissions}.{_moduleName}.ManagePermissions, L(\"Permission:ManagePermissions\"));");
                        }
                        builder.AppendLine("\t\t //Write additional permission definitions");
                        builder.AppendLine("\t\t /*");
                        foreach (var item in tables)
                        {
                            var moduleName = $"{item.Name}s";
                            builder.AppendLine($"\"Permission:{moduleName}\": \"{item.Comment}管理\",");
                        }
                        builder.AppendLine("\t\t */");
                    }
                    builder.AppendLine("\t}");

                    builder.AppendLine($"\t private static LocalizableString L(string name)");
                    builder.AppendLine("\t{");
                    {
                        builder.AppendLine($"\t\t return LocalizableString.Create<{Domain}Resource>(name);");
                    }
                    builder.AppendLine("\t}");

                }
                builder.AppendLine("\t}");
            }
            builder.AppendLine("}");
            return builder.ToString();
        }
    }
}
