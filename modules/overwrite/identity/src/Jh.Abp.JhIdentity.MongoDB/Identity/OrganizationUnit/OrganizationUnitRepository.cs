using Jh.Abp.MongoDB;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using Volo.Abp.Identity;
using Volo.Abp.Identity.MongoDB;
using Volo.Abp.MongoDB;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Jh.Abp.Common;

namespace Jh.Abp.JhIdentity
{
    public class OrganizationUnitRepository : CrudRepository<IAbpIdentityMongoDbContext, OrganizationUnit, System.Guid>, IOrganizationUnitRepository
    {
        public OrganizationUnitRepository(IMongoDbContextProvider<IAbpIdentityMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public virtual async Task<List<IdentityRole>> GetRolesAsync(
            Guid[] ids,
            bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            //TODO:测试mongodb关联查询
            var query = await GetMongoQueryableAsync();
            var roles = await query.Where(a => ids.Contains(a.Id)).SelectMany(a => a.Roles).ToListAsync(GetCancellationToken(cancellationToken));
            var orgRoleIds = roles.Select(a => a.RoleId).ToArray();
            return await (await GetMongoQueryableAsync<IdentityRole>()).Where(a => orgRoleIds.Contains(a.Id)).ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TreeAntdDto>> GetTreeAntdDtosAsync(CancellationToken cancellationToken = default)
        {
            var datas = await (await GetMongoQueryableAsync()).ToListAsync(GetCancellationToken(cancellationToken));
            return  datas.Select(a =>
               new TreeAntdDto(a.Id.ToString(), a.DisplayName, a.Code)
               {
                   parentId = a.ParentId.HasValue ? a.ParentId.Value.ToString() : null,
                   data = a
               }
            ).ToList();
        }

        public virtual Task<IQueryable<OrganizationUnit>> GetByLeaderAsync(IQueryable<OrganizationUnit> entity,Guid? LeaderId,string LeaderName)
        {
            //TODO:可以使用扩展表
            return Task.FromResult(entity);
        }
    }
}
