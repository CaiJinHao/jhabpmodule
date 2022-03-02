using AutoMapper;
using Volo.Abp.AutoMapper;
namespace Jh.Abp.Workflow
{
	public class WorkflowExtensionAttributeProfile : Profile
	{
		public WorkflowExtensionAttributeProfile()
		{
		CreateMap<WorkflowExtensionAttribute,WorkflowExtensionAttributeDto>();
		CreateMap<WorkflowExtensionAttributeCreateInputDto, WorkflowExtensionAttribute>().IgnoreCreationAuditedObjectProperties().Ignore(a => a.Id)
				.Ignore(a=>a.ExecutionPointer)
;
		CreateMap<WorkflowExtensionAttributeUpdateInputDto, WorkflowExtensionAttribute>().IgnoreCreationAuditedObjectProperties().Ignore(a => a.Id)
				.Ignore(a => a.ExecutionPointer)
;
		}
	}
}
