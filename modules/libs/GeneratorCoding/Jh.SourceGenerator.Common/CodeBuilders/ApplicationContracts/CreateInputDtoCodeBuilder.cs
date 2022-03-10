﻿using Jh.SourceGenerator.Common.GeneratorDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.SourceGenerator.Common.CodeBuilders
{
    public class CreateInputDtoCodeBuilder : CodeBuilderAbs
    {
        public CreateInputDtoCodeBuilder(TableDto tableDto, string filePath) : base(tableDto, filePath)
        {
            this.FileName = $"{table.Name}CreateInputDto";
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(@"using System;
using System.ComponentModel.DataAnnotations;
using Jh.Abp.Application.Contracts;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;");
            builder.AppendLine($"namespace {table.Namespace}");
            builder.AppendLine("{");
            {
                builder.AppendLine($"\t/// <summary>");
                builder.AppendLine($"\t/// {table.Comment}");
                builder.AppendLine($"\t/// </summary>");
                builder.AppendLine($"\tpublic class {FileName}: ");
                if (table.IsExtensibleObject)
                {
                    builder.AppendLine($"ExtensibleObject,");
                }
                if (table.IsConcurrencyStamp)
                {
                    builder.AppendLine($"IHasConcurrencyStamp,");
                }
                builder.AppendLine($"IMethodDto<{table.Name}>");
                //builder.AppendLine($",IMultiTenant");
                builder.AppendLine("\t{");
                {
                    foreach (var _field in table.FieldsCreateOrUpdateInput)
                    {
                        var nullable = _field.IsNullable ? "?" : "";//可空类型
                        builder.AppendLine($"\t\t/// <summary>");
                        builder.AppendLine($"\t\t/// {_field.Description}");
                        builder.AppendLine($"\t\t/// </summary>");
                        if (_field.IsRequired)
                        {
                            nullable = "";
                            builder.AppendLine($"\t\t[Required]");
                        }
                        builder.AppendLine($"\t\tpublic {_field.Type}{nullable} {_field.Name} " + "{ get; set; }");
                    }

                    if (table.IsConcurrencyStamp)
                    {
                        builder.AppendLine("\t\t/// <summary>");
                        builder.AppendLine("\t\t/// 并发检测字段 必须和数据库中的值一样才会允许更新");
                        builder.AppendLine("\t\t/// </summary>");
                        builder.AppendLine("\t\tpublic string ConcurrencyStamp { get; set; }");
                    }

                    builder.AppendLine("\t\t/// <summary>");
                    builder.AppendLine("\t\t/// 方法参数回调");
                    builder.AppendLine("\t\t/// </summary>");
                    builder.AppendLine($"\t\tpublic MethodDto<{table.Name}> MethodInput " + "{ get; set; }");

                    //builder.AppendLine($"\t\t public virtual Guid? TenantId " + "{ get; set; }");
                }
                builder.AppendLine("\t}");
            }
            builder.AppendLine("}");
            return builder.ToString();
        }
    }
}
