using System;
using System.ComponentModel.DataAnnotations;
using Jh.Abp.Application.Contracts.Dtos;
using Jh.Abp.Application.Contracts.Extensions;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
	/// <summary>
	/// 执行节点
	/// </summary>
	public class WorkflowExecutionPointerCreateInputDto: 
IMethodDto<WorkflowExecutionPointer>
,IMultiTenant
	{
		/// <summary>
		/// 工作流实例ID
		/// </summary>
		[Required]
		public Guid WorkflowInstanceId { get; set; }
		/// <summary>
		/// 步骤ID
		/// </summary>
		[Required]
		public Int32 StepId { get; set; }
		/// <summary>
		/// 是否激活
		/// </summary>
		[Required]
		public Boolean Active { get; set; }
		/// <summary>
		/// SleepUntil
		/// </summary>
		public DateTime? SleepUntil { get; set; }
		/// <summary>
		/// SleepUntil
		/// </summary>
		public String PersistenceData { get; set; }
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime? StartTime { get; set; }
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime? EndTime { get; set; }
		/// <summary>
		/// 事件名称
		/// </summary>
		public String EventName { get; set; }
		/// <summary>
		/// EventKey
		/// </summary>
		public String EventKey { get; set; }
		/// <summary>
		/// 是否事件发布
		/// </summary>
		[Required]
		public Boolean EventPublished { get; set; }
		/// <summary>
		/// 事件参数
		/// </summary>
		public String EventData { get; set; }
		/// <summary>
		/// 步骤名称
		/// </summary>
		public String StepName { get; set; }
		/// <summary>
		/// RetryCount
		/// </summary>
		[Required]
		public Int32 RetryCount { get; set; }
		/// <summary>
		/// Children
		/// </summary>
		public String Children { get; set; }
		/// <summary>
		/// ContextItem
		/// </summary>
		public String ContextItem { get; set; }
		/// <summary>
		/// 上一步骤ID
		/// </summary>
		public Guid? PredecessorId { get; set; }
		/// <summary>
		/// Outcome
		/// </summary>
		public String Outcome { get; set; }
		/// <summary>
		/// 节点状态
		/// </summary>
		[Required]
		public PointerStatus Status { get; set; }
		/// <summary>
		/// Scope
		/// </summary>
		public String Scope { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		public MethodDto<WorkflowExecutionPointer> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
