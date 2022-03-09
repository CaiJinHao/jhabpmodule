using Jh.SourceGenerator.Common.GeneratorDtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Jh.SourceGenerator.Common.CodeBuilders
{
    public class PermissionsCodeBuilder : CodeBuilderAbs
    {
        public PermissionsCodeBuilder(IEnumerable<TableDto> tableDto, string filePath) : base(tableDto, filePath)
        {
            this.FileName = $"{Domain}Permissions";
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(@"
using System;
using Volo.Abp.Reflection;");
            builder.AppendLine($"namespace {table.Namespace}");
            builder.AppendLine("{");
            {
                builder.AppendLine($"\tpublic class {FileName}");
                builder.AppendLine("\t{");
                {
                    builder.AppendLine($"\t\tpublic const string GroupName = \"{Domain}\";");

                    foreach (var item in tables)
                    {
                        var _moduleName = $"{table.Name}s";
                        builder.AppendLine($"\tpublic class {_moduleName} ");
                        builder.AppendLine("\t{");
                        {
                            //能查看列表就能导出
                            builder.AppendLine($"\t\tpublic const string Default = GroupName + \".{_moduleName}\";");
                            builder.AppendLine($"\t\tpublic const string Detail = Default + \".Detail\";");
                            //能创建就能批量创建
                            builder.AppendLine($"\t\tpublic const string Create = Default + \".Create\";");
                            //能更新就能批量更新
                            builder.AppendLine($"\t\tpublic const string Update = Default + \".Update\";");
                            builder.AppendLine($"\t\tpublic const string Delete = Default + \".Delete\";");
                            builder.AppendLine($"\t\tpublic const string BatchDelete = Default + \".BatchDelete\";");
                            builder.AppendLine($"\t\tpublic const string Recover = Default + \".Recover\";");
                            builder.AppendLine($"\t\tpublic const string ManagePermissions = Default + \".ManagePermissions\";");
                        }
                        builder.AppendLine("\t}");
                    }

                    builder.AppendLine($"\tpublic static string[] GetAll()");
                    builder.AppendLine("\t{");
                    builder.AppendLine($"\t\treturn ReflectionHelper.GetPublicConstantsRecursively(typeof({FileName}));");
                    builder.AppendLine("\t}");
                }
                builder.AppendLine("\t}");
            }
            builder.AppendLine("}");
            return builder.ToString();
        }
    }
}
