using Jh.Abp.Application.Contracts.Dtos;
using Jh.Abp.Application.Contracts.Extensions;
using System;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Application.Dtos;
namespace Jh.Abp.Workflow
{
	/// <summary>
	/// 工作流定义
	/// </summary>
	public class WorkflowDefinitionRetrieveInputDto: PagedAndSortedResultRequestDto, IMethodDto<WorkflowDefinition>
, IRetrieveDelete
,IMultiTenant
	{
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? Deleted { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		[Newtonsoft.Json.JsonIgnore]
		public MethodDto<WorkflowDefinition> MethodInput { get; set; }
		 public virtual Guid? TenantId { get; set; }
	}
}
