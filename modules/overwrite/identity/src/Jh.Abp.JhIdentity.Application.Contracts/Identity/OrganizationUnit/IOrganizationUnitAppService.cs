using Jh.Abp.Application.Contracts;
using Jh.Abp.Common;
using Jh.Abp.Common.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
    public interface IOrganizationUnitAppService
		: ICrudApplicationService< OrganizationUnitDto, OrganizationUnitDto, System.Guid, OrganizationUnitRetrieveInputDto, OrganizationUnitCreateInputDto, OrganizationUnitUpdateInputDto, OrganizationUnitDeleteInputDto>
	{
		Task RecoverAsync(Guid id);
		Task<ListResultDto<TreeAntdDto>> GetOrganizationTreeAsync();

		Task<ListResultDto<IdentityRoleDto>> GetRolesAsync(Guid organizationUnitId);

		Task<ListResultDto<IdentityUserDto>> GetMembersAsync(Guid organizationUnitId);

		Task CreateByRoleAsync(Guid roleId);
		Task<ListResultDto<OptionDto<Guid>>> GetOptionsAsync(string name);

		Task<ListResultDto<OptionDto<Guid>>> GetRoleOptionsAsync(Guid[] orgIds);
	}
}
