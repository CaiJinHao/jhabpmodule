using Jh.Abp.Extensions;
using System;
using Jh.Abp.Application.Contracts;
using System.Threading.Tasks;

namespace Jh.Abp.Workflow
{
	public interface IWorkflowInstanceRemoteService
		: IWorkflowInstanceBaseAppService
	{
		Task<string> StartWorkflowAsync(WorkflowStartDto workflowStartDto);
		Task<WorkflowCore.Models.WorkflowInstance> GetWorkflowInstanceAsync(string workflowId);
		Task WorkflowPublishEventAsync(WorkflowPublishEventDto workflowPublishEventDto);
	}
}
