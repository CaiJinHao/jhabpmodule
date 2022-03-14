using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Jh.Abp.JhIdentity
{
	public interface IIdentityUserBaseAppService
	{
		//用于添加与RemoteService公共的方法
		Task RecoverAsync(System.Guid id,bool isDelete);
		Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id);
		Task<ListResultDto<IdentityUserDto>> GetOrganizationsAsync(Guid id);
		Task<IdentityUserDto> GetCurrentAsync();
		Task UpdateLockoutEnabledAsync(Guid id, bool lockoutEnabled);
		Task<IdentityUserDto> GetSuperiorUserAsync(Guid userId);
	}
}
