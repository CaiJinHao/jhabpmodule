using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities;
namespace Jh.Abp.Workflow
{
	/// <summary>
	/// 订阅事件
	/// </summary>
	public class WorkflowEventSubscriptionDto: CreationAuditedEntityDto<System.Guid>
,IMultiTenant
	{
		/// <summary>
		/// WorkflowDefinitionId
		/// </summary>
		public Guid? WorkflowId { get; set; }
		/// <summary>
		/// StepId
		/// </summary>
		public Int32? StepId { get; set; }
		/// <summary>
		/// ExecutionPointerId
		/// </summary>
		public Guid? ExecutionPointerId { get; set; }
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
		 public virtual Guid? TenantId { get; set; }
	}
}
