using Jh.Abp.Application.Contracts.Dtos;
using Jh.Abp.Application.Contracts.Extensions;
using System;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities;
using Volo.Abp.ObjectExtending;
namespace Jh.Abp.Workflow
{
	/// <summary>
	/// 待办事项
	/// </summary>
	public class WorkflowBacklogUpdateInputDto: 
IMethodDto<WorkflowBacklog>
,IMultiTenant
	{
		/// <summary>
		/// WorkflowInstanceId
		/// </summary>
		public Guid? WorkflowInstanceId { get; set; }
		/// <summary>
		/// 待办人
		/// </summary>
		public Guid? BacklogUserId { get; set; }

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
		/// <summary>
		/// 是否删除
		/// </summary>
		public  bool IsDeleted { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		public MethodDto<WorkflowBacklog> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
