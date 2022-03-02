using Jh.Abp.Application.Contracts.Dtos;
using Jh.Abp.Application.Contracts.Extensions;
using System;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Application.Dtos;
using WorkflowCore.Models;

namespace Jh.Abp.Workflow
{
	/// <summary>
	/// 工作流实例
	/// </summary>
	public class WorkflowInstanceRetrieveInputDto: PagedAndSortedResultRequestDto, IMethodDto<WorkflowInstance>
,IMultiTenant
	{
		/// <summary>
		/// 方法参数回调
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public MethodDto<WorkflowInstance> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
		public virtual Guid? CreatorId { get; set; }
		public WorkflowStatus? Status { get; set; }
		public int? BusinessType { get; set; }
	}
}
