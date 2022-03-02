using AutoMapper;
using Volo.Abp.AutoMapper;
namespace Jh.Abp.Workflow
{
	public class WorkflowEventProfile : Profile
	{
		public WorkflowEventProfile()
		{
		CreateMap<WorkflowEvent,WorkflowEventDto>();
		CreateMap<WorkflowEventCreateInputDto, WorkflowEvent>().IgnoreCreationAuditedObjectProperties().Ignore(a => a.Id)
;
		CreateMap<WorkflowEventUpdateInputDto, WorkflowEvent>().IgnoreCreationAuditedObjectProperties().Ignore(a => a.Id)
;
		}
	}
}
