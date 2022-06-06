using Jh.Abp.Application.Contracts;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
namespace Jh.Abp.JhIdentity
{
    /// <summary>
    /// 
    /// </summary>
    public class OrganizationUnitRetrieveInputDto: PagedAndSortedResultRequestDto, IMethodDto<OrganizationUnit>
, IRetrieveDelete
	{
		/// <summary>
		/// 查询负责人
		/// </summary>
		public Guid? LeaderId { get; set; }
		public string LeaderName { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public Guid? ParentId { get; set; }
		/// <summary>
		/// 根据上级Code可以查询到下级所有组织
		/// </summary>
		public String Code { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public String DisplayName { get; set; }
		/// <summary>
		/// 是否删除
		/// </summary>
		public int? Deleted { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		[System.Text.Json.Serialization.JsonIgnore]
		[Newtonsoft.Json.JsonIgnore]
		public MethodDto<OrganizationUnit> MethodInput { get; set; }

		/// <summary>
		/// 组织树查询 上级及下级
		/// </summary>
		public Guid? OrParentId { get; set; }
	}
}
