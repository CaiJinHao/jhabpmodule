﻿using Jh.SourceGenerator.Common.GeneratorDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.SourceGenerator.Common.CodeBuilders
{
    public class RepositoryCodeBuilder : CodeBuilderAbs
    {
        public RepositoryCodeBuilder(TableDto tableDto, string filePath) : base(tableDto, filePath)
        {
            this.FileName = $"{table.Name}Repository";
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($@"
using {table.Namespace}.EntityFrameworkCore;
using Jh.Abp.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;");
            builder.AppendLine($"namespace {table.Namespace}");
            builder.AppendLine("{");
            {
                builder.AppendLine($"\tpublic class {FileName} : CrudRepository<{table.DbContext}, {table.Name}, {table.KeyType}>, I{table.Name}Repository");
                builder.AppendLine("\t{");
                //builder.AppendLine($"\t\t protected readonly I{table.Name}DapperRepository {table.Name}DapperRepository;");
                //, I{table.Name}DapperRepository {table.Name.ToLower()}DapperRepository
                builder.AppendLine($"\t\t public {FileName}(IDbContextProvider<{table.DbContext}> dbContextProvider) : base(dbContextProvider)");
                builder.AppendLine("\t\t{");
                builder.AppendLine($"\t\t\t{table.Name}DapperRepository={table.Name.ToLower()}DapperRepository;");
                builder.AppendLine("\t\t}");
                builder.AppendLine("\t}");
            }
            builder.AppendLine("}");
            return builder.ToString();
        }
    }
}
