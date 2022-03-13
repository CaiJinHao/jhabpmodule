using AutoMapper;
using Volo.Abp.AutoMapper;
namespace Jh.Abp.Workflow
{
	public class WorkflowInstanceProfile : Profile
	{
		public WorkflowInstanceProfile()
		{
		CreateMap<WorkflowInstance,WorkflowInstanceDto>();
		}
	}
}
