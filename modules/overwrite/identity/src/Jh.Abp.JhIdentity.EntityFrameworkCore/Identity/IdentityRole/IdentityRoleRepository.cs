using Jh.Abp.Common;
using Jh.Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace Jh.Abp.JhIdentity
{
    public class JhIdentityRoleRepository : CrudRepository<IIdentityDbContext, Volo.Abp.Identity.IdentityRole, System.Guid>, IJhIdentityRoleRepository
	{
		 public JhIdentityRoleRepository(IDbContextProvider<IIdentityDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}

		public virtual async Task<List<TreeAntdDto>> GetTreeAntdDtosAsync(CancellationToken cancellationToken = default)
		{
			var query = await GetQueryableAsync();
			return await query.Select(a =>
			   new TreeAntdDto(a.Id.ToString(), a.Name, a.NormalizedName) { isLeaf = true }
			).ToListAsync();
		}
	}
}
