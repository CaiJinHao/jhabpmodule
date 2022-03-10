using Jh.Abp.Application.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.MultiTenancy;
namespace Jh.Abp.Workflow
{
    /// <summary>
    /// 订阅事件
    /// </summary>
    public class WorkflowEventSubscriptionCreateInputDto: 
IMethodDto<WorkflowEventSubscription>
,IMultiTenant
	{
		/// <summary>
		/// WorkflowDefinitionId
		/// </summary>
		[Required]
		public Guid WorkflowId { get; set; }
		/// <summary>
		/// StepId
		/// </summary>
		[Required]
		public Int32 StepId { get; set; }
		/// <summary>
		/// ExecutionPointerId
		/// </summary>
		[Required]
		public Guid ExecutionPointerId { get; set; }
		/// <summary>
		/// WorkflowDefinitionId
		/// </summary>
		public String EventName { get; set; }
		/// <summary>
		/// WorkflowDefinitionId
		/// </summary>
		public String EventKey { get; set; }
		/// <summary>
		/// SubscribeAsOf
		/// </summary>
		public DateTime? SubscribeAsOf { get; set; }
		/// <summary>
		/// SubscriptionData
		/// </summary>
		public String SubscriptionData { get; set; }
		/// <summary>
		/// SubscriptionData
		/// </summary>
		public String ExternalToken { get; set; }
		/// <summary>
		/// ExternalWorkerId
		/// </summary>
		public String ExternalWorkerId { get; set; }
		/// <summary>
		/// ExternalTokenExpiry
		/// </summary>
		public DateTime? ExternalTokenExpiry { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		public MethodDto<WorkflowEventSubscription> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
