using Jh.Abp.Common;
using Jh.Abp.Domain;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace Jh.Abp.JhIdentity
{
    public interface IJhIdentityRoleRepository: ICrudRepository<IdentityRole, System.Guid>
	{
		Task<List<TreeAntdDto>> GetTreeAntdDtosAsync(CancellationToken cancellationToken = default);
	}
}
