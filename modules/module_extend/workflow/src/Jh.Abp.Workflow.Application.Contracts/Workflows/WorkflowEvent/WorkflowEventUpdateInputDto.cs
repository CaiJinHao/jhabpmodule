using Jh.Abp.Application.Contracts;
using System;
using Volo.Abp.MultiTenancy;

namespace Jh.Abp.Workflow
{
    /// <summary>
    /// 事件
    /// </summary>
    public class WorkflowEventUpdateInputDto: 
IMethodDto<WorkflowEvent>
,IMultiTenant
	{
		/// <summary>
		/// 事件名称
		/// </summary>
		public String EventName { get; set; }
		/// <summary>
		/// 事件Key
		/// </summary>
		public String EventKey { get; set; }
		/// <summary>
		/// 事件参数
		/// </summary>
		public String EventData { get; set; }
		/// <summary>
		/// 事件是否处理
		/// </summary>
		public Boolean? IsProcessed { get; set; }
		/// <summary>
		/// 事件时间
		/// </summary>
		public DateTime? EventTime { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		public MethodDto<WorkflowEvent> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
