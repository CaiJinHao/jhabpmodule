using Jh.Abp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
    public interface IIdentityUserRepository: ICrudRepository<IdentityUser, System.Guid>
	{
		Task<List<Volo.Abp.Identity.IdentityRole>> GetRolesAsync(
			Guid id,
			bool includeDetails = false,
			CancellationToken cancellationToken = default(CancellationToken));

		//todo:暂时没有用到组织负责人
		//Task<IdentityUser> GetSuperiorUserAsync(Guid userId,CancellationToken cancellationToken = default(CancellationToken));

		Task<List<OrganizationUnit>> GetOrganizationUnitsAsync(Guid id,CancellationToken cancellationToken = default(CancellationToken));

		Task<IQueryable<IdentityUser>> GetByOrganizationUnitCodeAsync(IQueryable<IdentityUser> entity, string organizationUnitCode);
	}
}
