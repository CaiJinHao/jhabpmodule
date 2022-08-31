using Jh.Abp.Application.Contracts;
using Jh.Abp.Common.Utils;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
    public interface IIdentityUserAppService
        : ICrudApplicationService<IdentityUserDto, IdentityUserDto, System.Guid, IdentityUserRetrieveInputDto, IdentityUserCreateInputDto, IdentityUserUpdateInputDto, IdentityUserDeleteInputDto>
    {
		Task ChangePasswordAsync(ChangePasswordInputDto input);
		Task RecoverAsync(System.Guid id);
		Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id);
		Task<ListResultDto<IdentityUserDto>> GetOrganizationsAsync(Guid id);
		Task<IdentityUserDto> GetCurrentAsync();
		Task UpdateLockoutEnabledAsync(Guid id, bool lockoutEnabled);
		Task<IdentityUserDto> GetSuperiorUserAsync(Guid userId);
		Task<ListResultDto<OptionDto<Guid>>> GetOptionsAsync();
	}
}
