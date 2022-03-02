using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Entities;
namespace Jh.Abp.Workflow
{
	/// <summary>
	/// 
	/// </summary>
	public class WorkflowScheduledCommandDto: CreationAuditedEntityDto<System.Guid>
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
		 public virtual Guid? TenantId { get; set; }
	}
}
