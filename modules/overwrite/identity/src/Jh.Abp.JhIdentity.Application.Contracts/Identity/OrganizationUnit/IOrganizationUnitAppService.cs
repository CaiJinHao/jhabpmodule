using Jh.Abp.Common;
using Jh.Abp.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
	public interface IOrganizationUnitAppService
		: ICrudApplicationService<OrganizationUnit, OrganizationUnitDto, OrganizationUnitDto, System.Guid, OrganizationUnitRetrieveInputDto, OrganizationUnitCreateInputDto, OrganizationUnitUpdateInputDto, OrganizationUnitDeleteInputDto>
	{
		Task RecoverAsync(Guid id, bool isDeleted = false);
		Task<List<TreeDto>> GetOrganizationTreeAsync();

		Task<List<IdentityRole>> GetRolesAsync(Guid organizationUnitId);

		Task<List<IdentityUser>> GetMembersAsync(Guid organizationUnitId);

		Task CreateByRoleAsync(Guid roleId);
	}
}
