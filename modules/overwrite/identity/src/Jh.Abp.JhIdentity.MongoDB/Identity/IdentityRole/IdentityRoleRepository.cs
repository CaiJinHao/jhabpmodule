using Jh.Abp.Common;
using Jh.Abp.MongoDB;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Identity.MongoDB;
using Volo.Abp.MongoDB;
using System.Linq;

namespace Jh.Abp.JhIdentity
{
    public class JhIdentityRoleRepository : CrudRepository<IAbpIdentityMongoDbContext, IdentityRole, System.Guid>, IJhIdentityRoleRepository
    {
        public JhIdentityRoleRepository(IMongoDbContextProvider<IAbpIdentityMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<List<TreeAntdDto>> GetTreeAntdDtosAsync(CancellationToken cancellationToken = default)
        {
            var datas = await (await GetMongoQueryableAsync()).Select(a => new IdentityRole(a.Id, a.Name, a.TenantId)).ToListAsync(GetCancellationToken(cancellationToken));
            return datas.Select(a => new TreeAntdDto(a.Id.ToString(), a.Name, a.NormalizedName) { isLeaf = true }).ToList();
        }
    }
}
