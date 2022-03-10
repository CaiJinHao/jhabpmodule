using Jh.Abp.Application.Contracts;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

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
