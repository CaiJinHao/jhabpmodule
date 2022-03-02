using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities;
namespace Jh.Abp.Workflow
{
	/// <summary>
	/// 待办事项
	/// </summary>
	public class WorkflowBacklogDto: CreationAuditedEntityDto<System.Guid>
,IMultiTenant
	{
		/// <summary>
		/// WorkflowInstanceId
		/// </summary>
		public Guid? WorkflowInstanceId { get; set; }
		/// <summary>
		/// 待办人
		/// </summary>
		public Guid BacklogUserId { get; set; }

		/// <summary>
		/// 待办人名称
		/// </summary>
		public string BacklogUserName { get; set; }
		/// <summary>
		/// 办理时间
		/// </summary>
		public DateTime? BacklogHandleTime { get; set; }
		/// <summary>
		/// 办理结果
		/// </summary>
		public BacklogResultType? BacklogResult { get; set; }
		/// <summary>
		/// 办理结果备注
		/// </summary>
		public String BacklogRemark { get; set; }
		 public virtual Guid? TenantId { get; set; }

		/// <summary>
		/// 用于发布事件
		/// </summary>
		public string EventName { get; set; }
		public string EventKey { get; set; }
		/// <summary>
		/// 业务类型
		/// </summary>
		public int? BusinessType { get; set; }
		/// <summary>
		/// 业务数据ID
		/// </summary>
		public string BusinessDataId { get; set; }
	}
}
