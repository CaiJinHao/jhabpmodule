using System;
using System.ComponentModel.DataAnnotations;
using Jh.Abp.Application.Contracts.Dtos;
using Jh.Abp.Application.Contracts.Extensions;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;
namespace Jh.Abp.Workflow
{
	/// <summary>
	/// 事件
	/// </summary>
	public class WorkflowEventCreateInputDto: 
IMethodDto<WorkflowEvent>
,IMultiTenant
	{
		/// <summary>
		/// 事件名称
		/// </summary>
		[Required]
		public String EventName { get; set; }
		/// <summary>
		/// 事件Key
		/// </summary>
		[Required]
		public String EventKey { get; set; }
		/// <summary>
		/// 事件参数
		/// </summary>
		public String EventData { get; set; }
		/// <summary>
		/// 事件是否处理
		/// </summary>
		[Required]
		public Boolean IsProcessed { get; set; }
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
