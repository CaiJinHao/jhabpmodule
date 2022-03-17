using Jh.Abp.Domain;
using System;
using System.Collections.Generic;
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
			CancellationToken cancellationToken = default);

		Task<IdentityUser> GetSuperiorUserAsync(Guid userId,CancellationToken cancellationToken = default);

		Task<List<OrganizationUnit>> GetOrganizationUnitsAsync(Guid id,CancellationToken cancellationToken = default);
	}
}
