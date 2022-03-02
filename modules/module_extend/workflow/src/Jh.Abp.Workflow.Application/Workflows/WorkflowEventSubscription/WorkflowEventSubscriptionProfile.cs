using AutoMapper;
using Volo.Abp.AutoMapper;
namespace Jh.Abp.Workflow
{
	public class WorkflowEventSubscriptionProfile : Profile
	{
		public WorkflowEventSubscriptionProfile()
		{
		CreateMap<WorkflowEventSubscription,WorkflowEventSubscriptionDto>();
		CreateMap<WorkflowEventSubscriptionCreateInputDto, WorkflowEventSubscription>().IgnoreCreationAuditedObjectProperties().Ignore(a => a.Id)
;
		CreateMap<WorkflowEventSubscriptionUpdateInputDto, WorkflowEventSubscription>().IgnoreCreationAuditedObjectProperties().Ignore(a => a.Id)
;
		}
	}
}
