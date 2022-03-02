using Jh.Abp.Extensions;
using System;
namespace Jh.Abp.Workflow
{
	public class WorkflowExtensionAttributeAppService
		: CrudApplicationService<WorkflowExtensionAttribute, WorkflowExtensionAttributeDto, WorkflowExtensionAttributeDto, System.Guid, WorkflowExtensionAttributeRetrieveInputDto, WorkflowExtensionAttributeCreateInputDto, WorkflowExtensionAttributeUpdateInputDto, WorkflowExtensionAttributeDeleteInputDto>,
		IWorkflowExtensionAttributeAppService
	{
		private readonly IWorkflowExtensionAttributeRepository WorkflowExtensionAttributeRepository;
		public WorkflowExtensionAttributeAppService(IWorkflowExtensionAttributeRepository repository) : base(repository)
		{
		WorkflowExtensionAttributeRepository = repository;
		}
	}
}
