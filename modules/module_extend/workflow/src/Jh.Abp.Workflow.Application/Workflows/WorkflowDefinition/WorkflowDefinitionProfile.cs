using AutoMapper;
using Volo.Abp.AutoMapper;
namespace Jh.Abp.Workflow
{
	public class WorkflowDefinitionProfile : Profile
	{
		public WorkflowDefinitionProfile()
		{
		CreateMap<WorkflowDefinition,WorkflowDefinitionDto>();
			CreateMap<WorkflowDefinitionCreateInputDto, WorkflowDefinition>().IgnoreFullAuditedObjectProperties().Ignore(a => a.Id).Ignore(a => a.TenantId)
	;
			CreateMap<WorkflowDefinitionUpdateInputDto, WorkflowDefinition>().IgnoreFullAuditedObjectProperties().Ignore(a => a.Id).Ignore(a => a.TenantId)
	;
		}
	}
}
