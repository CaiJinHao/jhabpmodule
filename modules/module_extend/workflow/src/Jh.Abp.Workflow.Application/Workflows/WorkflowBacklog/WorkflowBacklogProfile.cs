using AutoMapper;
using Volo.Abp.AutoMapper;
namespace Jh.Abp.Workflow
{
	public class WorkflowBacklogProfile : Profile
	{
		public WorkflowBacklogProfile()
		{
		CreateMap<WorkflowBacklog,WorkflowBacklogDto>()
				.Ignore(a=>a.EventKey)
				.Ignore(a => a.EventName)
				.Ignore(a => a.BusinessDataId)
				.Ignore(a => a.BusinessType)
				;
		CreateMap<WorkflowBacklogCreateInputDto, WorkflowBacklog>().IgnoreCreationAuditedObjectProperties().Ignore(a => a.Id)
;
		CreateMap<WorkflowBacklogUpdateInputDto, WorkflowBacklog>().IgnoreCreationAuditedObjectProperties().Ignore(a => a.Id)
;
		}
	}
}
