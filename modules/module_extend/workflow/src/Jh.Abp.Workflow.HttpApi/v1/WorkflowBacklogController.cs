using Jh.Abp.Application.Contracts.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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
	[RemoteService]
	[Route("api/v{apiVersion:apiVersion}/[controller]")]
	public class WorkflowBacklogController : WorkflowController, IWorkflowBacklogBaseAppService
	{
		private readonly IWorkflowBacklogAppService BacklogAppService;
		public IDataFilter<ISoftDelete> dataFilter { get; set; }
		public WorkflowBacklogController(IWorkflowBacklogAppService _BacklogAppService)
		{
			BacklogAppService = _BacklogAppService;
		}
		[Authorize(JhAbpWorkflowPermissions.Backlogs.Default)]
		[HttpGet]
		public virtual async Task<PagedResultDto<WorkflowBacklogDto>> GetListAsync([FromQuery] WorkflowBacklogRetrieveInputDto input)
		{
			using (dataFilter.Disable())
			{
				input.BacklogUserId = CurrentUser.Id;
				return await BacklogAppService.GetListAsync(input);
			}
		}
		[Authorize(JhAbpWorkflowPermissions.Backlogs.Default)]
		[Route("all")]
		[HttpGet]
		public virtual async Task<ListResultDto<WorkflowBacklogDto>> GetEntitysAsync([FromQuery] WorkflowBacklogRetrieveInputDto inputDto)
		{
			inputDto.BacklogUserId = CurrentUser.Id;
			return await BacklogAppService.GetEntitysAsync(inputDto);
		}
		[Authorize(JhAbpWorkflowPermissions.Backlogs.Detail)]
		[HttpGet("{id}")]
		public virtual async Task<WorkflowBacklog> GetAsync(System.Guid id)
		{
			return await BacklogAppService.GetEntityAsync(id);
		}
		[Authorize(JhAbpWorkflowPermissions.Backlogs.Create)]
		[HttpPost]
		public virtual async Task CreateAsync(WorkflowBacklogCreateInputDto input)
		{
			 await BacklogAppService.CreateAsync(input,true);
		}
		[Authorize(JhAbpWorkflowPermissions.Backlogs.BatchCreate)]
		[Route("items")]
		[HttpPost]
		public virtual async Task CreateAsync(WorkflowBacklogCreateInputDto[] input)
		{
			 await BacklogAppService.CreateAsync(input);
		}
		[Authorize(JhAbpWorkflowPermissions.Backlogs.Update)]
		[HttpPut("{id}")]
		public virtual async Task<WorkflowBacklogDto> UpdateAsync(System.Guid id, WorkflowBacklogUpdateInputDto input)
		{
			return await BacklogAppService.UpdateAsync(id, input);
		}
		[Authorize(JhAbpWorkflowPermissions.Backlogs.PortionUpdate)]
		[HttpPatch("{id}")]
		[HttpPatch("Patch/{id}")]
		public virtual async Task UpdatePortionAsync(System.Guid id, WorkflowBacklogUpdateInputDto inputDto)
		{
			 await BacklogAppService.UpdatePortionAsync(id, inputDto);
		}
		[Authorize(JhAbpWorkflowPermissions.Backlogs.Delete)]
		[HttpDelete("{id}")]
		public virtual async Task DeleteAsync(System.Guid id)
		{
			 await BacklogAppService.DeleteAsync(id);
		}
		[Authorize(JhAbpWorkflowPermissions.Backlogs.BatchDelete)]
		[HttpDelete]
		public virtual async Task DeleteAsync(WorkflowBacklogDeleteInputDto deleteInputDto)
		{
			 await BacklogAppService.DeleteAsync(deleteInputDto);
		}
		[Authorize(JhAbpWorkflowPermissions.Backlogs.BatchDelete)]
		[Route("keys")]
		[HttpDelete]
		public virtual async Task DeleteAsync([FromBody]System.Guid[] keys)
		{
			 await BacklogAppService.DeleteAsync(keys);
		}
		[Authorize(JhAbpWorkflowPermissions.Backlogs.Recover)]
		[HttpPatch]
		[HttpPut]
		[Route("{id}/Deleted")]
		public virtual Task UpdateDeletedAsync(System.Guid id, [FromBody] bool isDeleted)
		{
			throw new NotImplementedException();
		}
		[Authorize(JhAbpWorkflowPermissions.Backlogs.Default)]
		[Route("options")]
		[HttpGet]
		public virtual Task<ListResultDto<WorkflowBacklogDto>> GetOptionsAsync([FromBody]WorkflowBacklogRetrieveInputDto inputDto)
		{
			 throw new NotImplementedException();
		}
	}
}
