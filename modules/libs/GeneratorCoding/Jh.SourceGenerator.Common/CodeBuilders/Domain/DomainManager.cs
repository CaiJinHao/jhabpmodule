using System;
using System.Collections.Generic;
using System.Text;
using Jh.SourceGenerator.Common.GeneratorDtos;

namespace Jh.SourceGenerator.Common.CodeBuilders
{
    public class DomainManager : CodeBuilderAbs
    {
        public DomainManager(TableDto tableDto, string filePath) : base(tableDto, filePath)
        {
            this.FileName = $"{table.Name}Manager";
        }

        public override string ToString()
        {
            var builder =new StringBuilder();
            builder.AppendLine(@"
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;");
            builder.AppendLine($"namespace {table.Namespace}");
            builder.AppendLine("{");
            {
                builder.AppendLine($"\tpublic class {FileName}: DomainService");
                builder.AppendLine("\t{");
                builder.AppendLine($"\t\t protected readonly I{table.Name}Repository {table.Name}Repository => LazyServiceProvider.LazyGetRequiredService<I{table.Name}Repository>();");
                builder.AppendLine("\t\t ");
                builder.AppendLine("\t}");
            }
            builder.AppendLine("}");
            return builder.ToString();
        }
    }
}