using Jh.Abp.Application.Contracts.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using System.Collections.Generic;

namespace Jh.Abp.Workflow.v1
{
	/// <summary>
	/// 工作流定义
	/// </summary>
	[RemoteService]
	[Route("api/v{apiVersion:apiVersion}/[controller]")]
	public class WorkflowDefinitionController : WorkflowController, IWorkflowDefinitionRemoteService
	{
		private readonly IWorkflowDefinitionAppService WorkflowDefinitionAppService;
		public IDataFilter<ISoftDelete> dataFilter { get; set; }
		public WorkflowDefinitionController(IWorkflowDefinitionAppService _WorkflowDefinitionAppService)
		{
			WorkflowDefinitionAppService = _WorkflowDefinitionAppService;
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowDefinitions.Default)]
		[HttpGet]
		public virtual async Task<PagedResultDto<WorkflowDefinitionDto>> GetListAsync([FromQuery] WorkflowDefinitionRetrieveInputDto input)
		{
			using (dataFilter.Disable())
			{
				return await WorkflowDefinitionAppService.GetListAsync(input);
			}
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowDefinitions.Default)]
		[Route("all")]
		[HttpGet]
		public virtual async Task<ListResultDto<WorkflowDefinitionDto>> GetEntitysAsync([FromQuery] WorkflowDefinitionRetrieveInputDto inputDto)
		{
			return await WorkflowDefinitionAppService.GetEntitysAsync(inputDto);
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowDefinitions.Detail)]
		[HttpGet("{id}")]
		public virtual async Task<WorkflowDefinition> GetAsync(System.Guid id)
		{
			return await WorkflowDefinitionAppService.GetEntityAsync(id);
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowDefinitions.Create)]
		[HttpPost]
		public virtual async Task CreateAsync(WorkflowDefinitionCreateInputDto input)
		{
			await WorkflowDefinitionAppService.CreateAsync(input, true);
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowDefinitions.BatchCreate)]
		[Route("items")]
		[HttpPost]
		public virtual async Task CreateAsync(WorkflowDefinitionCreateInputDto[] input)
		{
			await WorkflowDefinitionAppService.CreateAsync(input);
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowDefinitions.Update)]
		[HttpPut("{id}")]
		public virtual async Task<WorkflowDefinitionDto> UpdateAsync(System.Guid id, WorkflowDefinitionUpdateInputDto input)
		{
			return await WorkflowDefinitionAppService.UpdateAsync(id, input);
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowDefinitions.PortionUpdate)]
		[HttpPatch("{id}")]
		[HttpPatch("Patch/{id}")]
		public virtual async Task UpdatePortionAsync(System.Guid id, WorkflowDefinitionUpdateInputDto inputDto)
		{
			await WorkflowDefinitionAppService.UpdatePortionAsync(id, inputDto);
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowDefinitions.Delete)]
		[HttpDelete("{id}")]
		public virtual async Task DeleteAsync(System.Guid id)
		{
			await WorkflowDefinitionAppService.DeleteAsync(id);
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowDefinitions.BatchDelete)]
		[HttpDelete]
		public virtual async Task DeleteAsync(WorkflowDefinitionDeleteInputDto deleteInputDto)
		{
			await WorkflowDefinitionAppService.DeleteAsync(deleteInputDto);
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowDefinitions.BatchDelete)]
		[Route("keys")]
		[HttpDelete]
		public virtual async Task DeleteAsync([FromBody] System.Guid[] keys)
		{
			await WorkflowDefinitionAppService.DeleteAsync(keys);
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowDefinitions.Recover)]
		[HttpPatch]
		[HttpPut]
		[Route("{id}/Deleted")]
		public virtual async Task UpdateDeletedAsync(System.Guid id, [FromBody] bool isDeleted)
		{
			using (dataFilter.Disable())
			{
				await WorkflowDefinitionAppService.UpdatePortionAsync(id, new WorkflowDefinitionUpdateInputDto()
				{
					MethodInput = new MethodDto<WorkflowDefinition>()
					{
						CreateOrUpdateEntityAction = (entity) => entity.IsDeleted = isDeleted
					}
				});
			}
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowDefinitions.Default)]
		[Route("options")]
		[HttpGet]
		public virtual  Task<ListResultDto<WorkflowDefinitionDto>> GetOptionsAsync([FromBody] WorkflowDefinitionRetrieveInputDto inputDto)
		{
			throw new NotImplementedException();
		}

		[Authorize(JhAbpWorkflowPermissions.WorkflowDefinitions.Default)]
		[HttpGet]
		[Route("Steps")]
		public virtual async Task<ListResultDto<WorkflowStepDto>> StepsAsync()
		{
			var datas= await WorkflowDefinitionAppService.GetApplicationStepsAsync();
			return new ListResultDto<WorkflowStepDto>(datas);
		}
	}
}
