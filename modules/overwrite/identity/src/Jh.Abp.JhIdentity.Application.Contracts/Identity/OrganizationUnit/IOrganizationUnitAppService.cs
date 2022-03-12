using Jh.Abp.Application.Contracts;
using Jh.Abp.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
    public interface IOrganizationUnitAppService
		: ICrudApplicationService<OrganizationUnit, OrganizationUnitDto, OrganizationUnitDto, System.Guid, OrganizationUnitRetrieveInputDto, OrganizationUnitCreateInputDto, OrganizationUnitUpdateInputDto, OrganizationUnitDeleteInputDto>
		, IOrganizationUnitBaseAppService
	{
		Task<List<TreeDto>> GetOrganizationTreeAsync();

		Task<List<IdentityRoleDto>> GetRolesAsync(Guid organizationUnitId);

		Task<List<IdentityUserDto>> GetMembersAsync(Guid organizationUnitId);

		Task CreateByRoleAsync(Guid roleId);
	}
}
