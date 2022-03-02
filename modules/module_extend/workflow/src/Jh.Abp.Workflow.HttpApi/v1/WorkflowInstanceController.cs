using Jh.Abp.Application.Contracts.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using Jh.Abp.Application.Contracts;
using Newtonsoft.Json.Linq;

namespace Jh.Abp.Workflow.v1
{
	/// <summary>
	/// 工作流实例
	/// </summary>
	[RemoteService]
	[Route("api/v{apiVersion:apiVersion}/[controller]")]
	public class WorkflowInstanceController : WorkflowController, IWorkflowInstanceRemoteService
	{
		private readonly IWorkflowInstanceAppService WorkflowInstanceAppService;
		public IDataFilter<ISoftDelete> dataFilter { get; set; }
		public WorkflowInstanceController(IWorkflowInstanceAppService _WorkflowInstanceAppService)
		{
			WorkflowInstanceAppService = _WorkflowInstanceAppService;
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowInstances.Default)]
		[HttpGet]
		public virtual async Task<PagedResultDto<WorkflowInstanceDto>> GetListAsync([FromQuery] WorkflowInstanceRetrieveInputDto input)
		{
			using (dataFilter.Disable())
			{
				input.CreatorId = CurrentUser.Id;
				return await WorkflowInstanceAppService.GetListAsync(input);
			}
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowInstances.Export)]
		[Route("all")]
		[HttpGet]
		public virtual async Task<ListResultDto<WorkflowInstanceDto>> GetEntitysAsync([FromQuery] WorkflowInstanceRetrieveInputDto inputDto)
		{
			using (dataFilter.Disable())
			{
				inputDto.CreatorId = CurrentUser.Id;
				return await WorkflowInstanceAppService.GetEntitysAsync(inputDto);
			}
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowInstances.Detail)]
		[HttpGet("{id}")]
		public virtual async Task<WorkflowInstance> GetAsync(System.Guid id)
		{
			return await WorkflowInstanceAppService.GetEntityAsync(id);
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowInstances.Create)]
		[HttpPost]
		public virtual async Task CreateAsync(WorkflowInstanceCreateInputDto input)
		{
			 await WorkflowInstanceAppService.CreateAsync(input,true);
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowInstances.Update)]
		[HttpPut("{id}")]
		public virtual async Task<WorkflowInstanceDto> UpdateAsync(System.Guid id, WorkflowInstanceUpdateInputDto input)
		{
			return await WorkflowInstanceAppService.UpdateAsync(id, input);
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowInstances.PortionUpdate)]
		[HttpPatch("{id}")]
		[HttpPatch("Patch/{id}")]
		public virtual async Task UpdatePortionAsync(System.Guid id, WorkflowInstanceUpdateInputDto inputDto)
		{
			 await WorkflowInstanceAppService.UpdatePortionAsync(id, inputDto);
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowInstances.Delete)]
		[HttpDelete("{id}")]
		public virtual async Task DeleteAsync(System.Guid id)
		{
			 await WorkflowInstanceAppService.DeleteAsync(id);
		}
		[Authorize(JhAbpWorkflowPermissions.WorkflowInstances.BatchDelete)]
		[Route("keys")]
		[HttpDelete]
		public virtual async Task DeleteAsync([FromBody]System.Guid[] keys)
		{
			 await WorkflowInstanceAppService.DeleteAsync(keys);
		}

		[Authorize(JhAbpWorkflowPermissions.WorkflowInstances.BatchCreate)]
		[Route("items")]
		[HttpPost]
		public virtual async Task CreateAsync(WorkflowInstanceCreateInputDto[] input)
		{
			await WorkflowInstanceAppService.CreateAsync(input);
		}

		[Authorize(JhAbpWorkflowPermissions.WorkflowInstances.BatchDelete)]
		[HttpDelete]
		public virtual async Task DeleteAsync(WorkflowInstanceDeleteInputDto deleteInputDto)
		{
			await WorkflowInstanceAppService.DeleteAsync(deleteInputDto);
		}

		[Authorize(JhAbpWorkflowPermissions.WorkflowInstances.Recover)]
		[HttpPatch]
		[Route("{id}/Deleted")]
		public Task UpdateDeletedAsync(Guid id, bool isDeleted)
        {
            throw new NotImplementedException();
        }

		[Authorize(JhAbpWorkflowPermissions.WorkflowInstances.Default)]
		[Route("options")]
		[HttpGet]
		public Task<ListResultDto<WorkflowInstanceDto>> GetOptionsAsync(WorkflowInstanceRetrieveInputDto inputDto)
        {
            throw new NotImplementedException();
        }

		[Authorize(JhAbpWorkflowPermissions.WorkflowInstances.Create)]
		[HttpPost]
		[Route("StartWorkflow")]
		public async Task<string> StartWorkflowAsync([FromBody] WorkflowStartDto workflowStartDto)
		{
			return await WorkflowInstanceAppService.StartWorkflowAsync(workflowStartDto);
		}

		/// <summary>
		/// 实例详情
		/// </summary>
		/// <param name="workflowId"></param>
		/// <returns></returns>
		[Authorize(JhAbpWorkflowPermissions.WorkflowInstances.Default)]
		[HttpGet]
		[Route("Detail/{workflowId}")]
		public async Task<WorkflowCore.Models.WorkflowInstance> GetWorkflowInstanceAsync(string workflowId)
		{
			return await WorkflowInstanceAppService.GetWorkflowInstanceDeatilAsync(workflowId);
		}

		/// <summary>
		/// 激活事件
		/// </summary>
		/// <param name="workflowId"></param>
		/// <returns></returns>
		[Authorize(JhAbpWorkflowPermissions.WorkflowInstances.Create)]
		[HttpPost]
		[Route("PublishEvent")]
		public async Task WorkflowPublishEventAsync([FromBody] WorkflowPublishEventDto workflowPublishEventDto)
		{
			//判断发布事件人和待办人是否一致
            await WorkflowInstanceAppService.WorkflowPublishEventAsync(workflowPublishEventDto);
		}
	}
}
