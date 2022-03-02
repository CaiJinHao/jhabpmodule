using AutoMapper;
using Volo.Abp.AutoMapper;
namespace Jh.Abp.Workflow
{
	public class WorkflowExecutionPointerProfile : Profile
	{
		public WorkflowExecutionPointerProfile()
		{
		CreateMap<WorkflowExecutionPointer,WorkflowExecutionPointerDto>();
		CreateMap<WorkflowExecutionPointerCreateInputDto, WorkflowExecutionPointer>().Ignore(a => a.Id).Ignore(a=>a.WorkflowInstance).Ignore(a => a.ExtensionAttributes)
;
		CreateMap<WorkflowExecutionPointerUpdateInputDto, WorkflowExecutionPointer>().Ignore(a => a.Id).Ignore(a => a.WorkflowInstance).Ignore(a => a.ExtensionAttributes)
;
		}
	}
}
