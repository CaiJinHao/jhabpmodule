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
    /// 工作流实例
    /// </summary>
    [RemoteService]
	[Route("api/v{apiVersion:apiVersion}/[controller]")]
	public class WorkflowInstanceController : WorkflowController, IWorkflowInstanceAppService
	{
		protected IDataFilter DataFilter => LazyServiceProvider.LazyGetRequiredService<IDataFilter>();
		private readonly IWorkflowInstanceAppService WorkflowInstanceAppService;
		public WorkflowInstanceController(IWorkflowInstanceAppService _WorkflowInstanceAppService)
		{
			WorkflowInstanceAppService = _WorkflowInstanceAppService;
		}

		[Authorize(WorkflowPermissions.WorkflowInstances.Default)]
		[HttpGet]
		public virtual async Task<PagedResultDto<WorkflowInstanceDto>> GetListAsync([FromQuery] WorkflowInstanceRetrieveInputDto input)
		{
			using (DataFilter.Disable<ISoftDelete>())
			{
				return await WorkflowInstanceAppService.GetListAsync(input);
			}
		}

		[Authorize(WorkflowPermissions.WorkflowInstances.Default)]
		[Route("all")]
		[HttpGet]
		public virtual async Task<ListResultDto<WorkflowInstanceDto>> GetEntitysAsync([FromQuery] WorkflowInstanceRetrieveInputDto inputDto)
		{
			return await WorkflowInstanceAppService.GetEntitysAsync(inputDto);
		}

		[Authorize(WorkflowPermissions.WorkflowInstances.Create)]
		[HttpPost]
		[Route("StartWorkflow")]
		public async Task<string> StartWorkflowAsync([FromBody] WorkflowStartDto workflowStartDto)
		{
			return await WorkflowInstanceAppService.StartWorkflowAsync(workflowStartDto);
		}

		[Authorize(WorkflowPermissions.WorkflowInstances.Default)]
		[HttpGet]
		[Route("Detail/{workflowId}")]
		public async Task<WorkflowCore.Models.WorkflowInstance> GetWorkflowInstanceDeatilAsync(string workflowId)
		{
			return await WorkflowInstanceAppService.GetWorkflowInstanceDeatilAsync(workflowId);
		}

		[Authorize(WorkflowPermissions.WorkflowInstances.Create)]
		[HttpPost]
		[Route("PublishEvent")]
		public async Task WorkflowPublishEventAsync([FromBody] WorkflowPublishEventDto workflowPublishEventDto)
		{
			//判断发布事件人和待办人是否一致
            await WorkflowInstanceAppService.WorkflowPublishEventAsync(workflowPublishEventDto);
		}

        public Task DeleteAsync(Guid[] keys)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePortionAsync(Guid id, WorkflowInstanceUpdateInputDto inputDto)
        {
            throw new NotImplementedException();
        }

        public Task<WorkflowInstanceDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<WorkflowInstanceDto> CreateAsync(WorkflowInstanceCreateInputDto input)
        {
            throw new NotImplementedException();
        }

        public Task<WorkflowInstanceDto> UpdateAsync(Guid id, WorkflowInstanceUpdateInputDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
