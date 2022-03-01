﻿using Jh.SourceGenerator.Common.GeneratorDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jh.SourceGenerator.Common.CodeBuilders
{
    public class ControllerCodeBuilder : CodeBuilderAbs
    {
        public ControllerCodeBuilder(TableDto tableDto, string filePath) : base(tableDto, filePath)
        {
            FileName = $"{table.Name}Controller";
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(@"using Jh.Abp.Application.Contracts.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;");
            builder.AppendLine($"namespace {table.Namespace}.v1");
            builder.AppendLine("{");
            {
                builder.AppendLine($"\t/// <summary>");
                builder.AppendLine($"\t/// {table.Comment}");
                builder.AppendLine($"\t/// </summary>");
                builder.AppendLine("\t[RemoteService]");
                builder.AppendLine("\t[Route(\"api/v{apiVersion:apiVersion}/[controller]\")]");
                builder.AppendLine($"\tpublic class {FileName} : {table.ControllerBase},I{table.Name}BaseAppService");
                builder.AppendLine("\t{");
                {
                    var moduleName = $"{table.Name}s";
                    var groupName = $"{table.GetGroupName()}Permissions";

                    builder.AppendLine($"\t\tprivate readonly I{table.Name}AppService {table.Name}AppService;");
                    builder.AppendLine("\t\tpublic IDataFilter<ISoftDelete> dataFilter { get; set; }");
                    builder.AppendLine($"\t\tpublic {FileName}(I{table.Name}AppService _{table.Name}AppService)");
                    {
                        builder.AppendLine("\t\t{");
                        builder.AppendLine($"\t\t\t{table.Name}AppService = _{table.Name}AppService;");
                        builder.AppendLine("\t\t}");
                    }

                    builder.AppendLine($"\t\t[Authorize({groupName}.{moduleName}.Default)]");
                    builder.AppendLine("\t\t[HttpGet]");
                    builder.AppendLine($"\t\tpublic virtual async Task<PagedResultDto<{table.Name}Dto>> GetListAsync([FromQuery] {table.Name}RetrieveInputDto input)");
                    {
                        builder.AppendLine("\t\t{");
                        builder.AppendLine("\t\t\tusing (dataFilter.Disable())");
                        builder.AppendLine("\t\t\t{");
                        builder.AppendLine($"\t\t\t\treturn await {table.Name}AppService.GetListAsync(input);");
                        builder.AppendLine("\t\t\t}");
                        builder.AppendLine("\t\t}");
                    }

                    builder.AppendLine($"\t\t[Authorize({groupName}.{moduleName}.Default)]");
                    builder.AppendLine("\t\t[Route(\"all\")]");
                    builder.AppendLine("\t\t[HttpGet]");
                    builder.AppendLine($"\t\tpublic virtual async Task<ListResultDto<{table.Name}Dto>> GetEntitysAsync([FromQuery] {table.Name}RetrieveInputDto inputDto)");
                    {
                        builder.AppendLine("\t\t{");
                        builder.AppendLine($"\t\t\treturn await {table.Name}AppService.GetEntitysAsync(inputDto);");
                        builder.AppendLine("\t\t}");
                    }

                    builder.AppendLine($"\t\t[Authorize({groupName}.{moduleName}.Detail)]");
                    builder.AppendLine("\t\t[HttpGet(\"{id}\")]");
                    builder.AppendLine($"\t\tpublic virtual async Task<{table.Name}> GetAsync({table.KeyType} id)");
                    {
                        builder.AppendLine("\t\t{");
                        builder.AppendLine($"\t\t\treturn await {table.Name}AppService.GetEntityAsync(id);");
                        builder.AppendLine("\t\t}");
                    }

                    builder.AppendLine($"\t\t[Authorize({groupName}.{moduleName}.Create)]");
                    builder.AppendLine("\t\t[HttpPost]");
                    builder.AppendLine($"\t\tpublic virtual async Task CreateAsync({table.Name}CreateInputDto input)");
                    {
                        builder.AppendLine("\t\t{");
                        builder.AppendLine($"\t\t\t await {table.Name}AppService.CreateAsync(input,true);");
                        builder.AppendLine("\t\t}");
                    }

                    
                    //不需要暴漏的外部，需要时手动添加
                    builder.AppendLine($"\t\t[Authorize({groupName}.{moduleName}.BatchCreate)]");
                    builder.AppendLine("\t\t[Route(\"items\")]");
                    builder.AppendLine("\t\t[HttpPost]");
                    builder.AppendLine($"\t\tpublic virtual async Task CreateAsync({table.Name}CreateInputDto[] input)");
                    {
                        builder.AppendLine("\t\t{");
                        builder.AppendLine($"\t\t\t await {table.Name}AppService.CreateAsync(input);");
                        builder.AppendLine("\t\t}");
                    }

                    builder.AppendLine($"\t\t[Authorize({groupName}.{moduleName}.Update)]");
                    builder.AppendLine("\t\t[HttpPut(\"{id}\")]");
                    builder.AppendLine($"\t\tpublic virtual async Task<{table.Name}Dto> UpdateAsync({table.KeyType} id, {table.Name}UpdateInputDto input)");
                    {
                        builder.AppendLine("\t\t{");
                        builder.AppendLine($"\t\t\treturn await {table.Name}AppService.UpdateAsync(id, input);");
                        builder.AppendLine("\t\t}");
                    }

                    builder.AppendLine($"\t\t[Authorize({groupName}.{moduleName}.PortionUpdate)]");
                    builder.AppendLine("\t\t[HttpPatch(\"{id}\")]");
                    builder.AppendLine("\t\t[HttpPatch(\"Patch/{id}\")]");
                    builder.AppendLine($"\t\tpublic virtual async Task UpdatePortionAsync({table.KeyType} id, {table.Name}UpdateInputDto inputDto)");
                    {
                        builder.AppendLine("\t\t{");
                        builder.AppendLine($"\t\t\t await {table.Name}AppService.UpdatePortionAsync(id, inputDto);");
                        builder.AppendLine("\t\t}");
                    }

                    builder.AppendLine($"\t\t[Authorize({groupName}.{moduleName}.Delete)]");
                    builder.AppendLine("\t\t[HttpDelete(\"{id}\")]");
                    builder.AppendLine($"\t\tpublic virtual async Task DeleteAsync({table.KeyType} id)");
                    {
                        builder.AppendLine("\t\t{");
                        builder.AppendLine($"\t\t\t await {table.Name}AppService.DeleteAsync(id);");
                        builder.AppendLine("\t\t}");
                    }


                    //不需要暴漏的外部，需要时手动添加
                    builder.AppendLine($"\t\t[Authorize({groupName}.{moduleName}.BatchDelete)]");
                    builder.AppendLine("\t\t[HttpDelete]");
                    builder.AppendLine($"\t\tpublic virtual async Task DeleteAsync({table.Name}DeleteInputDto deleteInputDto)");
                    {
                        builder.AppendLine("\t\t{");
                        builder.AppendLine($"\t\t\t await {table.Name}AppService.DeleteAsync(deleteInputDto);");
                        builder.AppendLine("\t\t}");
                    }

                    builder.AppendLine($"\t\t[Authorize({groupName}.{moduleName}.BatchDelete)]");
                    builder.AppendLine("\t\t[Route(\"keys\")]");
                    builder.AppendLine("\t\t[HttpDelete]");
                    builder.AppendLine($"\t\tpublic virtual async Task DeleteAsync([FromBody]{table.KeyType}[] keys)");
                    {
                        builder.AppendLine("\t\t{");
                        builder.AppendLine($"\t\t\t await {table.Name}AppService.DeleteAsync(keys);");
                        builder.AppendLine("\t\t}");
                    }

                    if (table.IsDelete)
                    {
                        builder.AppendLine($"\t\t[Authorize({groupName}.{moduleName}.Recover)]");
                        builder.AppendLine("\t\t[HttpPatch]");
                        builder.AppendLine("\t\t[HttpPut]");
                        builder.AppendLine("\t\t[Route(\"{id}/Deleted\")]");
                        builder.AppendLine($"\t\tpublic virtual async Task UpdateDeletedAsync({table.KeyType} id, [FromBody] bool isDeleted)");
                        {
                            builder.AppendLine("\t\t{");
                            builder.AppendLine("\t\t\tusing (dataFilter.Disable())");
                            builder.AppendLine("\t\t\t{");
                            builder.AppendLine($"\t\t\t\tawait {table.Name}AppService.UpdatePortionAsync(id, new {table.Name}UpdateInputDto()");
                            builder.AppendLine("\t\t\t\t{");
                            builder.AppendLine($"\t\t\t\t\tMethodInput = new MethodDto<{table.Name}>()");
                            builder.AppendLine("\t\t\t\t\t{");
                            builder.AppendLine("\t\t\t\t\t\t CreateOrUpdateEntityAction = (entity) => entity.IsDeleted = isDeleted");
                            builder.AppendLine("\t\t\t\t\t}");
                            builder.AppendLine("\t\t\t\t});");
                            builder.AppendLine("\t\t\t}");
                            builder.AppendLine("\t\t}");
                        }
                    }
                    else
                    {
                        builder.AppendLine($"\t\t[Authorize({groupName}.{moduleName}.Recover)]");
                        builder.AppendLine("\t\t[HttpPatch]");
                        builder.AppendLine("\t\t[HttpPut]");
                        builder.AppendLine("\t\t[Route(\"{id}/Deleted\")]");
                        builder.AppendLine($"\t\tpublic virtual  Task UpdateDeletedAsync({table.KeyType} id, [FromBody] bool isDeleted)");
                        {
                            builder.AppendLine("\t\t{");
                            builder.AppendLine("\t\t\t throw new NotImplementedException();");
                            builder.AppendLine("\t\t}");
                        }
                    }

                    builder.AppendLine($"\t\t[Authorize({groupName}.{moduleName}.Default)]");
                    builder.AppendLine("\t\t[Route(\"options\")]");
                    builder.AppendLine("\t\t[HttpGet]");
                    builder.AppendLine($"\t\tpublic virtual Task<ListResultDto<{table.Name}Dto>> GetOptionsAsync([FromBody]{table.Name}RetrieveInputDto inputDto)");
                    {
                        builder.AppendLine("\t\t{");
                        builder.AppendLine($"\t\t\t //inputDto.MethodInput = new MethodDto<{table.Name}>()");
                        builder.AppendLine("\t\t\t  //{");
                        builder.AppendLine("\t\t\t\t//SelectAction = (query) => query.Select(a => new {table.Name}(a.Id){Name = a.Name})");
                        builder.AppendLine("\t\t\t  //{");
                        builder.AppendLine($"\t\t\t throw new NotImplementedException();");
                        builder.AppendLine("\t\t}");
                    }
                }
                builder.AppendLine("\t}");
            }
            builder.AppendLine("}");
            return builder.ToString();
        }
    }
}
