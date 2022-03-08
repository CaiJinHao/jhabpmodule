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
