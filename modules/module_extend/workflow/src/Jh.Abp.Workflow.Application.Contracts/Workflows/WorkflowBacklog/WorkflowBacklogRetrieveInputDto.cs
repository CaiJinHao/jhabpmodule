using Jh.Abp.Application.Contracts;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace Jh.Abp.Workflow
{
    /// <summary>
    /// 待办事项
    /// </summary>
    public class WorkflowBacklogRetrieveInputDto: PagedAndSortedResultRequestDto, IMethodDto<WorkflowBacklog>
, IRetrieveDelete
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
	}
}
