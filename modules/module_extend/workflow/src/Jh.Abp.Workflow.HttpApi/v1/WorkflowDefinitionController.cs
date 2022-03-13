using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
namespace Jh.Abp.Workflow.v1
{
	/// <summary>
	/// 工作流定义
	/// </summary>
	[Area(WorkflowRemoteServiceConsts.ModuleName)]
	[RemoteService(Name = WorkflowRemoteServiceConsts.RemoteServiceName)]
	[Route("api/v{apiVersion:apiVersion}/[controller]")]
	public class WorkflowDefinitionController : WorkflowController, IWorkflowDefinitionBaseAppService
	{
		protected readonly IWorkflowDefinitionAppService WorkflowDefinitionAppService;
		protected IDataFilter DataFilter => LazyServiceProvider.LazyGetRequiredService<IDataFilter>();
		public WorkflowDefinitionController(IWorkflowDefinitionAppService _WorkflowDefinitionAppService)
		{
			WorkflowDefinitionAppService = _WorkflowDefinitionAppService;
		}

		[Authorize(WorkflowPermissions.WorkflowDefinitions.Create)]
		[HttpPost]
		public virtual async Task CreateAsync(WorkflowDefinitionCreateInputDto input)
		{
			await WorkflowDefinitionAppService.CreateAsync(input, true);
		}

		[Authorize(WorkflowPermissions.WorkflowDefinitions.Delete)]
		[HttpDelete("{id}")]
		public virtual async Task DeleteAsync(System.Guid id)
		{
			await WorkflowDefinitionAppService.DeleteAsync(id);
		}

		[Authorize(WorkflowPermissions.WorkflowDefinitions.BatchDelete)]
		[Route("keys")]
		[HttpDelete]
		public virtual async Task DeleteAsync([FromBody] System.Guid[] keys)
		{
			await WorkflowDefinitionAppService.DeleteAsync(keys);
		}

		[Authorize(WorkflowPermissions.WorkflowDefinitions.Update)]
		[HttpPut("{id}")]
		public virtual async Task<WorkflowDefinitionDto> UpdateAsync(System.Guid id, WorkflowDefinitionUpdateInputDto input)
		{
			return await WorkflowDefinitionAppService.UpdateAsync(id, input);
		}

		[Authorize(WorkflowPermissions.WorkflowDefinitions.Update)]
		[HttpPatch("{id}")]
		[HttpPatch("Patch/{id}")]
		public virtual async Task UpdatePortionAsync(System.Guid id, WorkflowDefinitionUpdateInputDto inputDto)
		{
			await WorkflowDefinitionAppService.UpdatePortionAsync(id, inputDto);
		}

		[Authorize(WorkflowPermissions.WorkflowDefinitions.Recover)]
		[HttpPatch]
		[HttpPut]
		[Route("{id}/Recover")]
		public async Task RecoverAsync(System.Guid id)
		{
			await WorkflowDefinitionAppService.RecoverAsync(id);
		}

		[Authorize(WorkflowPermissions.WorkflowDefinitions.Default)]
		[HttpGet]
		public virtual async Task<PagedResultDto<WorkflowDefinitionDto>> GetListAsync([FromQuery] WorkflowDefinitionRetrieveInputDto input)
		{
			using (DataFilter.Disable<ISoftDelete>())
			{
				return await WorkflowDefinitionAppService.GetListAsync(input);
			}
		}

		[Authorize(WorkflowPermissions.WorkflowDefinitions.Default)]
		[Route("all")]
		[HttpGet]
		public virtual async Task<ListResultDto<WorkflowDefinitionDto>> GetEntitysAsync([FromQuery] WorkflowDefinitionRetrieveInputDto inputDto)
		{
			return await WorkflowDefinitionAppService.GetEntitysAsync(inputDto);
		}

		[Authorize(WorkflowPermissions.WorkflowDefinitions.Detail)]
		[HttpGet("{id}")]
		public virtual async Task<WorkflowDefinitionDto> GetAsync(System.Guid id)
		{
			return await WorkflowDefinitionAppService.GetAsync(id);
		}

		/*
				[Authorize(WorkflowPermissions.WorkflowDefinitions.Default)]
				[Route("options")]
				[HttpGet]
				public virtual Task<ListResultDto<WorkflowDefinitionDto>> GetOptionsAsync([FromBody]WorkflowDefinitionRetrieveInputDto inputDto)
				{
					 //inputDto.MethodInput = new MethodDto<WorkflowDefinition>()
					  //{
						//SelectAction = (query) => query.Select(a => new {table.Name}(a.Id){Name = a.Name})
					  //{
					 throw new NotImplementedException();
				}

		*/

		[Authorize(WorkflowPermissions.WorkflowDefinitions.Default)]
		[HttpGet]
		[Route("Steps")]
		public virtual async Task<ListResultDto<WorkflowStepDto>> StepsAsync()
		{
			var datas= await WorkflowDefinitionAppService.GetApplicationStepsAsync();
			return new ListResultDto<WorkflowStepDto>(datas);
		}
	}
}
