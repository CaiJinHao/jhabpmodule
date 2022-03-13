using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
	public class WorkflowInstanceController : WorkflowController, IWorkflowInstanceRemoteService
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

		/// <summary>
		/// 实例详情
		/// </summary>
		/// <param name="workflowId"></param>
		/// <returns></returns>
		[Authorize(WorkflowPermissions.WorkflowInstances.Default)]
		[HttpGet]
		[Route("Detail/{workflowId}")]
		public async Task<WorkflowCore.Models.WorkflowInstance> GetWorkflowInstanceAsync(string workflowId)
		{
			return await WorkflowInstanceAppService.GetWorkflowInstanceDeatilAsync(workflowId);
		}

		/// <summary>
		/// 激活事件
		/// </summary>
		[Authorize(WorkflowPermissions.WorkflowInstances.Create)]
		[HttpPost]
		[Route("PublishEvent")]
		public async Task WorkflowPublishEventAsync([FromBody] WorkflowPublishEventDto workflowPublishEventDto)
		{
			//判断发布事件人和待办人是否一致
            await WorkflowInstanceAppService.WorkflowPublishEventAsync(workflowPublishEventDto);
		}
	}
}
