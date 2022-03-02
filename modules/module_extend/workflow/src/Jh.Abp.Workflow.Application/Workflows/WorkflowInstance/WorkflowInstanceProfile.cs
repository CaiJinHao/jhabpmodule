using AutoMapper;
using Volo.Abp.AutoMapper;
namespace Jh.Abp.Workflow
{
	public class WorkflowInstanceProfile : Profile
	{
		public WorkflowInstanceProfile()
		{
		CreateMap<WorkflowInstance,WorkflowInstanceDto>();
		CreateMap<WorkflowInstanceCreateInputDto, WorkflowInstance>().IgnoreCreationAuditedObjectProperties().Ignore(a => a.Id)
				.Ignore(a=>a.ExecutionPointers)
;
		CreateMap<WorkflowInstanceUpdateInputDto, WorkflowInstance>().IgnoreCreationAuditedObjectProperties().Ignore(a => a.Id)
				.Ignore(a=>a.ExecutionPointers)
;
		}
	}
}
