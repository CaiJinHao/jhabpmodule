using Jh.Abp.EntityFrameworkCore;
using Jh.Abp.JhIdentity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Jh.Abp.Common;

namespace Jh.Abp.JhIdentity
{
    public class OrganizationUnitRepository : CrudRepository<IIdentityDbContext, OrganizationUnit, System.Guid>, IOrganizationUnitRepository
	{
        public OrganizationUnitRepository(IDbContextProvider<IIdentityDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<OrganizationUnit>> WithDetailsAsync()
        {
            var query = await GetQueryableAsync();
            return query.Include(x => x.Roles);
        }

        public virtual async Task<List<IdentityRole>> GetRolesAsync(
            Guid[] ids,
            bool includeDetails = false,
            CancellationToken cancellationToken = default)
        {
            var query = (await GetQueryableAsync()).AsNoTracking();
            var roles = await query.IncludeDetails(true).Where(a => ids.Contains(a.Id)).SelectMany(a => a.Roles).ToListAsync();
            var orgRoleIds = roles.Select(a => a.RoleId).ToArray();
            return await (await GetQueryableAsync<IdentityRole>()).AsNoTracking().Where(a => orgRoleIds.Contains(a.Id)).ToListAsync();
        }

        public virtual async Task<List<TreeAntdDto>> GetTreeAntdDtosAsync(CancellationToken cancellationToken = default)
        {
            var query = (await GetQueryableAsync()).AsNoTracking();
            return await query.Select(a =>
               new TreeAntdDto(a.Id.ToString(), a.DisplayName, a.Code)
               {
                   parentId = a.ParentId.HasValue ? a.ParentId.Value.ToString() : null,
                   data = a
               }
            ).ToListAsync();
        }

        public virtual Task<IQueryable<OrganizationUnit>> GetByLeaderAsync(IQueryable<OrganizationUnit> entity, Guid? LeaderId, string LeaderName)
        {
            return Task.FromResult(entity);
            //if (LeaderId.HasValue)
            //{
            //    entity = entity.Where(a => EF.Property<Guid>(a, nameof(JhOrganizationUnit.LeaderId)) == LeaderId.Value);
            //}
            //if (!string.IsNullOrEmpty(LeaderName))
            //{
            //    entity = entity.Where(a => EF.Property<string>(a, nameof(JhOrganizationUnit.LeaderName)).StartsWith(LeaderName));
            //}
            //return Task.FromResult(entity);
        }
    }
}
