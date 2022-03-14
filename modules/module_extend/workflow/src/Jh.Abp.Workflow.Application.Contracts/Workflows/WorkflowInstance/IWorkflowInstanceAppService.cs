using Jh.Abp.Application.Contracts;
using System.Threading.Tasks;

namespace Jh.Abp.Workflow
{
    public interface IWorkflowInstanceAppService
		: ICrudApplicationService<WorkflowInstance, WorkflowInstanceDto, WorkflowInstanceDto, System.Guid, WorkflowInstanceRetrieveInputDto, WorkflowInstanceCreateInputDto, WorkflowInstanceUpdateInputDto, WorkflowInstanceDeleteInputDto>
	{
		/// <summary>
		/// ����������
		/// </summary>
		/// <param name="workflowStartDto"></param>
		/// <returns></returns>
		Task<string> StartWorkflowAsync(WorkflowStartDto workflowStartDto);

		/// <summary>
		/// ��ȡ����������
		/// </summary>
		/// <param name="workflowId"></param>
		/// <returns></returns>
		Task<WorkflowCore.Models.WorkflowInstance> GetWorkflowInstanceDeatilAsync(string workflowId);

		/// <summary>
		/// ����/�����������¼�
		/// </summary>
		/// <param name="workflowPublishEventDto"></param>
		/// <returns></returns>
		Task WorkflowPublishEventAsync(WorkflowPublishEventDto workflowPublishEventDto);
	}
}
