using Jh.Abp.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using Volo.Abp.Identity;
using Jh.Abp.Common;

namespace Jh.Abp.JhIdentity
{
    public interface IOrganizationUnitRepository: ICrudRepository<OrganizationUnit, System.Guid>
	{
        Task<List<IdentityRole>> GetRolesAsync(
            Guid[] ids,
            bool includeDetails = false,
            CancellationToken cancellationToken = default(CancellationToken));

        Task<List<TreeAntdDto>> GetTreeAntdDtosAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
