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
	/// 待办事项
	/// </summary>
	[Area(WorkflowRemoteServiceConsts.ModuleName)]
	[RemoteService(Name = WorkflowRemoteServiceConsts.RemoteServiceName)]
	[Route("api/v{apiVersion:apiVersion}/[controller]")]
	public class WorkflowBacklogController : WorkflowController, IWorkflowBacklogAppService
	{
		protected readonly IWorkflowBacklogAppService WorkflowBacklogAppService;
		protected IDataFilter DataFilter => LazyServiceProvider.LazyGetRequiredService<IDataFilter>();
		public WorkflowBacklogController(IWorkflowBacklogAppService _WorkflowBacklogAppService)
		{
			WorkflowBacklogAppService = _WorkflowBacklogAppService;
		}

		[Authorize(WorkflowPermissions.WorkflowBacklogs.Create)]
		[HttpPost]
		public virtual async Task<WorkflowBacklogDto> CreateAsync(WorkflowBacklogCreateInputDto input)
		{
			return await WorkflowBacklogAppService.CreateAsync(input);
		}

		[Authorize(WorkflowPermissions.WorkflowBacklogs.Delete)]
		[HttpDelete("{id}")]
		public virtual async Task DeleteAsync(System.Guid id)
		{
			await WorkflowBacklogAppService.DeleteAsync(id);
		}

		[Authorize(WorkflowPermissions.WorkflowBacklogs.BatchDelete)]
		[Route("keys")]
		[HttpDelete]
		public virtual async Task DeleteAsync([FromBody] System.Guid[] keys)
		{
			await WorkflowBacklogAppService.DeleteAsync(keys);
		}

		[Authorize(WorkflowPermissions.WorkflowBacklogs.Update)]
		[HttpPut("{id}")]
		public virtual async Task<WorkflowBacklogDto> UpdateAsync(System.Guid id, WorkflowBacklogUpdateInputDto input)
		{
			return await WorkflowBacklogAppService.UpdateAsync(id, input);
		}

		[Authorize(WorkflowPermissions.WorkflowBacklogs.Update)]
		[HttpPatch("{id}")]
		[HttpPatch("Patch/{id}")]
		public virtual async Task UpdatePortionAsync(System.Guid id, WorkflowBacklogUpdateInputDto inputDto)
		{
			await WorkflowBacklogAppService.UpdatePortionAsync(id, inputDto);
		}

		[Authorize(WorkflowPermissions.WorkflowBacklogs.Default)]
		[HttpGet]
		public virtual async Task<PagedResultDto<WorkflowBacklogDto>> GetListAsync([FromQuery] WorkflowBacklogRetrieveInputDto input)
		{
			using (DataFilter.Disable<ISoftDelete>())
			{
				return await WorkflowBacklogAppService.GetListAsync(input);
			}
		}

		[Authorize(WorkflowPermissions.WorkflowBacklogs.Default)]
		[Route("all")]
		[HttpGet]
		public virtual async Task<ListResultDto<WorkflowBacklogDto>> GetEntitysAsync([FromQuery] WorkflowBacklogRetrieveInputDto inputDto)
		{
			return await WorkflowBacklogAppService.GetEntitysAsync(inputDto);
		}

		[Authorize(WorkflowPermissions.WorkflowBacklogs.Detail)]
		[HttpGet("{id}")]
		public virtual async Task<WorkflowBacklogDto> GetAsync(System.Guid id)
		{
			return await WorkflowBacklogAppService.GetAsync(id);
		}

		/*
				[Authorize(WorkflowPermissions.WorkflowBacklogs.Default)]
				[Route("options")]
				[HttpGet]
				public virtual Task<ListResultDto<WorkflowBacklogDto>> GetOptionsAsync([FromBody]WorkflowBacklogRetrieveInputDto inputDto)
				{
					 //inputDto.MethodInput = new MethodDto<WorkflowBacklog>()
					  //{
						//SelectAction = (query) => query.Select(a => new {table.Name}(a.Id){Name = a.Name})
					  //{
					 throw new NotImplementedException();
				}

		*/
	}
}
