using Jh.Abp.Application.Contracts;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;

namespace Jh.Abp.JhIdentity
{
    /// <summary>
    /// 
    /// </summary>
    public class OrganizationUnitUpdateInputDto: 
ExtensibleObject, IHasConcurrencyStamp,
IMethodDto<OrganizationUnit>
	{
		/// <summary>
		/// 
		/// </summary>
		public Guid? ParentId { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public String DisplayName { get; set; }
		/// <summary>
		/// 是否删除
		/// </summary>
		public  bool IsDeleted { get; set; }
		/// <summary>
		/// 并发检测字段 必须和数据库中的值一样才会允许更新
		/// </summary>
		public string ConcurrencyStamp { get; set; }
		/// <summary>
		/// 方法参数回调
		/// </summary>
		[System.Text.Json.Serialization.JsonIgnore]
		public MethodDto<OrganizationUnit> MethodInput { get; set; }

		public Guid[] RoleIds { get; set; }
	}
}
