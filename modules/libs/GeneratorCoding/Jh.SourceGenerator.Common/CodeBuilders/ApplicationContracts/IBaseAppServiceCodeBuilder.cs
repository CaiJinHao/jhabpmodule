using Jh.SourceGenerator.Common.GeneratorDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.SourceGenerator.Common.CodeBuilders
{
    public class IBaseAppServiceCodeBuilder : CodeBuilderAbs
    {
        public IBaseAppServiceCodeBuilder(TableDto tableDto, string filePath) : base(tableDto, filePath)
        {
            this.FileName = $"I{table.Name}BaseAppService";
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(@"using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;");
            builder.AppendLine($"namespace {table.Namespace}");
            builder.AppendLine("{");
            {
                builder.AppendLine($"\tpublic interface {FileName}");
                builder.AppendLine("\t{");
                builder.AppendLine("\t}");
            }
            builder.AppendLine("}");
            return builder.ToString();
        }
    }
}
