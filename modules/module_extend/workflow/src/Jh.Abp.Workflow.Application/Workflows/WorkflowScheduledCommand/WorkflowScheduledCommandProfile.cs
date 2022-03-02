using AutoMapper;
using Volo.Abp.AutoMapper;
namespace Jh.Abp.Workflow
{
	public class WorkflowScheduledCommandProfile : Profile
	{
		public WorkflowScheduledCommandProfile()
		{
		CreateMap<WorkflowScheduledCommand,WorkflowScheduledCommandDto>();
		CreateMap<WorkflowScheduledCommandCreateInputDto, WorkflowScheduledCommand>().IgnoreCreationAuditedObjectProperties().Ignore(a => a.Id)
;
		CreateMap<WorkflowScheduledCommandUpdateInputDto, WorkflowScheduledCommand>().IgnoreCreationAuditedObjectProperties().Ignore(a => a.Id)
;
		}
	}
}
