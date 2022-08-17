using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Identity.MongoDB;
using Volo.Abp.MongoDB;

namespace Jh.Abp.JhIdentity
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(Volo.Abp.Identity.IIdentityUserRepository),typeof(MongoIdentityUserRepository))]
    public class EMongoIdentityUserRepositoryOverride : MongoIdentityUserRepository
    {
        public EMongoIdentityUserRepositoryOverride(IMongoDbContextProvider<IAbpIdentityMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }


       /* /// <summary>
        /// 针对用户组织的处理
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<List<string>> GetRoleNamesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var IdentityUserRoles = await GetMongoQueryableAsync<IdentityUserRole>();
            var IdentityRoles = await GetMongoQueryableAsync<IdentityRole>();
            var OrganizationUnitRoles = await GetMongoQueryableAsync<OrganizationUnitRole>();
            var IdentityUserOrganizationUnits = await GetMongoQueryableAsync<IdentityUserOrganizationUnit>();
            var OrganizationUnits = await GetMongoQueryableAsync<OrganizationUnit>();
            //用户所属的角色
            var query = from userRole in IdentityUserRoles
                        join role in IdentityRoles on userRole.RoleId equals role.Id
                        where userRole.UserId == id
                        select role.Id;

            IQueryable<Guid> resultRoleIds;
            //这个用户所属的组织列表
            var organizationUnitIds = IdentityUserOrganizationUnits.Where(q => q.UserId == id).Select(q => q.OrganizationUnitId).ToArray();
            if (organizationUnitIds.Any())
            {
                //指定组织列表下的角色
                var organizationRoleIds = await (
                    from ouRole in OrganizationUnitRoles
                    join ou in OrganizationUnits on ouRole.OrganizationUnitId equals ou.Id
                    where organizationUnitIds.Contains(ouRole.OrganizationUnitId)
                    select ouRole.RoleId
                ).ToListAsync(GetCancellationToken(cancellationToken));

                resultRoleIds = query.Where(a => organizationRoleIds.Contains(a));//用户所属角色 并且所属角色在所属组织下
            }
            else
            {
                resultRoleIds = query;
            }
            var resultQuery = IdentityRoles.Where(r => resultRoleIds.Contains(r.Id)).Select(n => n.Name);
            return await resultQuery.ToListAsync(GetCancellationToken(cancellationToken));
        }

        /// <summary>
        /// 针对用户组织的处理
        /// </summary>
        /// <param name="id"></param>
        /// <param name="includeDetails"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<List<IdentityRole>> GetRolesAsync(Guid id, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            var IdentityUserRoles = await GetMongoQueryableAsync<IdentityUserRole>();
            var IdentityRoles = await GetMongoQueryableAsync<IdentityRole>();
            var IdentityUserOrganizationUnits = await GetMongoQueryableAsync<IdentityUserOrganizationUnit>();
            var OrganizationUnits = await GetMongoQueryableAsync<OrganizationUnit>();
            var OrganizationUnitRoles = await GetMongoQueryableAsync<OrganizationUnitRole>();
            //用户所属的角色
            var query = from userRole in IdentityUserRoles
                        join role in IdentityRoles on userRole.RoleId equals role.Id
                        where userRole.UserId == id
                        select role;

            //TODO: Needs improvement
            //这个用户所属的组织列表
            var userOrganizationsQuery = from userOrg in IdentityUserOrganizationUnits
                                         join ou in OrganizationUnits on userOrg.OrganizationUnitId equals ou.Id
                                         where userOrg.UserId == id
                                         select ou;
            IQueryable<IdentityRole> resultQuery;
            if (userOrganizationsQuery.Any())
            {
                //指定组织列表下的角色
                var orgUserRoleQuery = OrganizationUnitRoles
                    .Where(q => userOrganizationsQuery
                    .Select(t => t.Id)
                    .Contains(q.OrganizationUnitId))
                    .Select(t => t.RoleId)
                    .ToArray();
                //var orgRoles = dbContext.Roles.Where(q => orgUserRoleQuery.Contains(q.Id));
                //var resultQuery = query.Union(orgRoles);
                resultQuery = query.Where(a => orgUserRoleQuery.Contains(a.Id));//用户所属角色 并且所属角色在所属组织下
            }
            else
            {
                resultQuery = query;
            }
            return await resultQuery.ToListAsync(GetCancellationToken(cancellationToken));
        }*/
    }
}
