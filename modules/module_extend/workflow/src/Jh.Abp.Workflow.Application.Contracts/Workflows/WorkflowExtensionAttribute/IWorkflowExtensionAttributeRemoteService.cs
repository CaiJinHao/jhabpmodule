using Jh.Abp.Extensions;
using System;
using Jh.Abp.Application.Contracts;
namespace Jh.Abp.Workflow
{
	public interface IWorkflowExtensionAttributeRemoteService
		: IRequestRemoteService<WorkflowExtensionAttribute, WorkflowExtensionAttributeDto, WorkflowExtensionAttributeDto, System.Guid, WorkflowExtensionAttributeRetrieveInputDto, WorkflowExtensionAttributeCreateInputDto, WorkflowExtensionAttributeUpdateInputDto, WorkflowExtensionAttributeDeleteInputDto>
 , IWorkflowExtensionAttributeBaseAppService
	{
	}
}
