using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities;
namespace Jh.Abp.Workflow
{
	/// <summary>
	/// 事件
	/// </summary>
	public class WorkflowEventDto: CreationAuditedEntityDto<System.Guid>
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
		 public virtual Guid? TenantId { get; set; }
	}
}
