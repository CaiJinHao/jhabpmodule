using Jh.Abp.Application.Contracts.Dtos;
using Jh.Abp.Application.Contracts.Extensions;
using System;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Application.Dtos;
namespace Jh.Abp.Workflow
{
	/// <summary>
	/// 订阅事件
	/// </summary>
	public class WorkflowEventSubscriptionRetrieveInputDto: PagedAndSortedResultRequestDto, IMethodDto<WorkflowEventSubscription>
,IMultiTenant
	{
		/// <summary>
		/// 方法参数回调
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public MethodDto<WorkflowEventSubscription> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
