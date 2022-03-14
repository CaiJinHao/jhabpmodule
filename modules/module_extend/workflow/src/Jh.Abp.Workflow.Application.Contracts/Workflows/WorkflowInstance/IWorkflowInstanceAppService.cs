using Jh.Abp.Application.Contracts;
using System.Threading.Tasks;

namespace Jh.Abp.Workflow
{
    public interface IWorkflowInstanceAppService
		: ICrudApplicationService<WorkflowInstance, WorkflowInstanceDto, WorkflowInstanceDto, System.Guid, WorkflowInstanceRetrieveInputDto, WorkflowInstanceCreateInputDto, WorkflowInstanceUpdateInputDto, WorkflowInstanceDeleteInputDto>
	{
		/// <summary>
		/// 启动工作流
		/// </summary>
		/// <param name="workflowStartDto"></param>
		/// <returns></returns>
		Task<string> StartWorkflowAsync(WorkflowStartDto workflowStartDto);

		/// <summary>
		/// 获取工作流详情
		/// </summary>
		/// <param name="workflowId"></param>
		/// <returns></returns>
		Task<WorkflowCore.Models.WorkflowInstance> GetWorkflowInstanceDeatilAsync(string workflowId);

		/// <summary>
		/// 发布/触发工作流事件
		/// </summary>
		/// <param name="workflowPublishEventDto"></param>
		/// <returns></returns>
		Task WorkflowPublishEventAsync(WorkflowPublishEventDto workflowPublishEventDto);
	}
}
