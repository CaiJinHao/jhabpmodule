using AutoMapper;
using Volo.Abp.AutoMapper;
namespace Jh.Abp.Workflow
{
	public class WorkflowExecutionErrorProfile : Profile
	{
		public WorkflowExecutionErrorProfile()
		{
		CreateMap<WorkflowExecutionError,WorkflowExecutionErrorDto>();
		CreateMap<WorkflowExecutionErrorCreateInputDto, WorkflowExecutionError>().IgnoreCreationAuditedObjectProperties().Ignore(a => a.Id)
;
		CreateMap<WorkflowExecutionErrorUpdateInputDto, WorkflowExecutionError>().IgnoreCreationAuditedObjectProperties().Ignore(a => a.Id)
;
		}
	}
}
