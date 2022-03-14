using Jh.Abp.Application.Contracts;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
    public interface IIdentityUserAppService
        : ICrudApplicationService<IdentityUser, IdentityUserDto, IdentityUserDto, System.Guid, IdentityUserRetrieveInputDto, IdentityUserCreateInputDto, IdentityUserUpdateInputDto, IdentityUserDeleteInputDto>
    {
		Task RecoverAsync(System.Guid id, bool isDelete);
		Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id);
		Task<ListResultDto<IdentityUserDto>> GetOrganizationsAsync(Guid id);
		Task<IdentityUserDto> GetCurrentAsync();
		Task UpdateLockoutEnabledAsync(Guid id, bool lockoutEnabled);
		Task<IdentityUserDto> GetSuperiorUserAsync(Guid userId);
	}
}
