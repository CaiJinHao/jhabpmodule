using Jh.Abp.Application.Contracts;
using System;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.MultiTenancy;
namespace Jh.Abp.Workflow
{
    /// <summary>
    /// 待办事项
    /// </summary>
    public class WorkflowBacklogCreateInputDto: 
IMethodDto<WorkflowBacklog>
,IMultiTenant
	{
		/// <summary>
		/// WorkflowInstanceId
		/// </summary>
		[Required]
		public Guid WorkflowInstanceId { get; set; }
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
		[Required]
		public BacklogResultType BacklogResult { get; set; }
		/// <summary>
		/// 办理结果备注
		/// </summary>
		public String BacklogRemark { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		public MethodDto<WorkflowBacklog> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
