using Jh.Abp.Extensions;
using Volo.Abp.Identity;
using System;
namespace Jh.Abp.JhIdentity
{
	public interface IJhIdentityRoleAppService
		: ICrudApplicationService<IdentityRole, IdentityRoleDto, IdentityRoleDto, System.Guid, IdentityRoleRetrieveInputDto, IdentityRoleCreateInputDto, IdentityRoleUpdateInputDto, IdentityRoleDeleteInputDto>
	{
	}
}
