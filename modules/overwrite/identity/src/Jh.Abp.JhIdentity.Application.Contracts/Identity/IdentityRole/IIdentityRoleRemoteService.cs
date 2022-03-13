using Jh.Abp.Application.Contracts;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
	public interface IIdentityRoleRemoteService
		: IRequestRemoteService<IdentityRole, IdentityRoleDto, IdentityRoleDto, System.Guid, IdentityRoleRetrieveInputDto, IdentityRoleCreateInputDto, IdentityRoleUpdateInputDto, IdentityRoleDeleteInputDto>
 , IIdentityRoleBaseAppService
	{
	}
}
