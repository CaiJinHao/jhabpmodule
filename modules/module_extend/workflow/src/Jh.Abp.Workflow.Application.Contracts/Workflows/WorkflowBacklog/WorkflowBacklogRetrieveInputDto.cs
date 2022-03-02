using Jh.Abp.Application.Contracts.Dtos;
using Jh.Abp.Application.Contracts.Extensions;
using System;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Application.Dtos;
namespace Jh.Abp.Workflow
{
	/// <summary>
	/// 待办事项
	/// </summary>
	public class WorkflowBacklogRetrieveInputDto: PagedAndSortedResultRequestDto, IMethodDto<WorkflowBacklog>
, IRetrieveDelete
,IMultiTenant
	{
		/// <summary>
		/// 待办人
		/// </summary>
		public Guid? BacklogUserId { get; set; }
		/// <summary>
		/// 办理结果
		/// </summary>
		public BacklogResultType? BacklogResult { get; set; }
		public int? BusinessType { get; set; }

		/// <summary>
		/// 是否删除
		/// </summary>
		public int? Deleted { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public MethodDto<WorkflowBacklog> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
