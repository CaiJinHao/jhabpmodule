using Jh.Abp.Application.Contracts;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.MultiTenancy;

namespace Jh.Abp.Workflow
{
    /// <summary>
    /// 工作流定义
    /// </summary>
    public class WorkflowDefinitionRetrieveInputDto: PagedAndSortedResultRequestDto, IMethodDto<WorkflowDefinition>
, IRetrieveDelete
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
	}
}
