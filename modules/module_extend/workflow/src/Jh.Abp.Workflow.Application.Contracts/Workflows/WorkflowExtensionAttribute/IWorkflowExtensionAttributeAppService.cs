using Jh.Abp.Application.Contracts;
namespace Jh.Abp.Workflow
{
    public interface IWorkflowExtensionAttributeAppService
		: ICrudApplicationService<WorkflowExtensionAttribute, WorkflowExtensionAttributeDto, WorkflowExtensionAttributeDto, System.Guid, WorkflowExtensionAttributeRetrieveInputDto, WorkflowExtensionAttributeCreateInputDto, WorkflowExtensionAttributeUpdateInputDto, WorkflowExtensionAttributeDeleteInputDto>
,IWorkflowExtensionAttributeBaseAppService
	{
	}
}
