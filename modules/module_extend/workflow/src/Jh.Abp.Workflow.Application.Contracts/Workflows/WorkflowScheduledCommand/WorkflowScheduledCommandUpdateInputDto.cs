using Jh.Abp.Application.Contracts;
using System;
using Volo.Abp.MultiTenancy;

namespace Jh.Abp.Workflow
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkflowScheduledCommandUpdateInputDto: 
IMethodDto<WorkflowScheduledCommand>
,IMultiTenant
	{
		/// <summary>
		/// 命令名称
		/// </summary>
		public String CommandName { get; set; }
		/// <summary>
		/// 参数
		/// </summary>
		public String Data { get; set; }
		public long? ExecuteTime { get; set; }

		/// <summary>
		/// 方法参数回调
		/// </summary>
		public MethodDto<WorkflowScheduledCommand> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
