using Jh.Abp.Application.Contracts;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
    public interface IIdentityUserAppService
		: ICrudApplicationService<IdentityUser, IdentityUserDto, IdentityUserDto, System.Guid, IdentityUserRetrieveInputDto, IdentityUserCreateInputDto, IdentityUserUpdateInputDto, IdentityUserDeleteInputDto>
	{
		Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid id);
		Task<IdentityUserDto> GetCurrentAsync();
		Task<IdentityUserDto> GetSuperiorUserAsync(Guid userId);
	}
}
