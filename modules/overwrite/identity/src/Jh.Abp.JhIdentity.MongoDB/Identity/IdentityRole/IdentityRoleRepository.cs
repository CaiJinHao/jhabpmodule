using Jh.Abp.Common;
using Jh.Abp.MongoDB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Identity.MongoDB;
using Volo.Abp.MongoDB;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.MongoDB;


namespace Jh.Abp.JhIdentity
{
    public class JhIdentityRoleRepository : CrudRepository<IAbpIdentityMongoDbContext, Volo.Abp.Identity.IdentityRole, System.Guid>, IJhIdentityRoleRepository
    {
        public JhIdentityRoleRepository(IMongoDbContextProvider<IAbpIdentityMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<List<TreeAntdDto>> GetTreeAntdDtosAsync(CancellationToken cancellationToken = default)
        {
            var datas = await (await GetMongoQueryableAsync()).ToListAsync(GetCancellationToken(cancellationToken));
            return datas.Select(a => new TreeAntdDto(a.Id.ToString(), a.Name, a.NormalizedName) { isLeaf = true }).ToList();
        }
    }
}
