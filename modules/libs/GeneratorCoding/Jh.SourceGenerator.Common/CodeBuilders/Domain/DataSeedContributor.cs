using Jh.SourceGenerator.Common.GeneratorDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.SourceGenerator.Common.CodeBuilders
{
    public class DataSeedContributor : CodeBuilderAbs
    {
        public DataSeedContributor(TableDto tableDto, string filePath) : base(tableDto, filePath)
        {
            this.FileName = $"{table.Name}DataSeedContributor";
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(@"
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;");
            builder.AppendLine($"namespace {table.Namespace}");
            builder.AppendLine("{");
            {
                builder.AppendLine("/*");

                builder.AppendLine($"\tpublic class {FileName}: : IDataSeedContributor, ITransientDependency");
                builder.AppendLine("\t{");
                builder.AppendLine($"\t\t protected I{table.Name}Repository {table.Name}Repository => LazyServiceProvider.LazyGetRequiredService<I{table.Name}Repository>();");
                builder.AppendLine("\t\t public async Task SeedAsync(DataSeedContext context)");
                builder.AppendLine("\t\t {");
                builder.AppendLine("\t\t }");
                builder.AppendLine("\t}");

                builder.AppendLine("*/");
            }
            builder.AppendLine("}");
            return builder.ToString();
        }
    }
}
