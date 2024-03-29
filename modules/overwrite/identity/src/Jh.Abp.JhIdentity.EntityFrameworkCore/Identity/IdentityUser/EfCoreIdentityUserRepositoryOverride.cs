﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace Jh.Abp.JhIdentity
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(Volo.Abp.Identity.IIdentityUserRepository),typeof(EfCoreIdentityUserRepository))]
    public class EfCoreIdentityUserRepositoryOverride : EfCoreIdentityUserRepository
    {
        public EfCoreIdentityUserRepositoryOverride(IDbContextProvider<IIdentityDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        /// <summary>
        /// 针对用户组织的处理
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task<List<string>> GetRoleNamesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var dbContext = await GetDbContextAsync();
            //用户所属的角色
            var query = from userRole in dbContext.Set<IdentityUserRole>()
                        join role in dbContext.Roles on userRole.RoleId equals role.Id
                        where userRole.UserId == id
                        select role.Id;

            IQueryable<Guid> resultRoleIds;
            //这个用户所属的组织列表
            var organizationUnitIds = dbContext.Set<IdentityUserOrganizationUnit>().Where(q => q.UserId == id).Select(q => q.OrganizationUnitId).ToArray();
            if (organizationUnitIds.Any())
            {
                //指定组织列表下的角色
                var organizationRoleIds = await (
                    from ouRole in dbContext.Set<OrganizationUnitRole>()
                    join ou in dbContext.Set<OrganizationUnit>() on ouRole.OrganizationUnitId equals ou.Id
                    where organizationUnitIds.Contains(ouRole.OrganizationUnitId)
                    select ouRole.RoleId
                ).ToListAsync(GetCancellationToken(cancellationToken));

                resultRoleIds = query.Where(a => organizationRoleIds.Contains(a));//用户所属角色 并且所属角色在所属组织下
            }
            else
            {
                resultRoleIds = query;
            }
            var resultQuery = dbContext.Roles.Where(r => resultRoleIds.Contains(r.Id)).Select(n => n.Name);
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
            var dbContext = await GetDbContextAsync();

            //用户所属的角色
            var query = from userRole in dbContext.Set<IdentityUserRole>()
                        join role in dbContext.Roles.IncludeDetails(includeDetails) on userRole.RoleId equals role.Id
                        where userRole.UserId == id
                        select role;

            //TODO: Needs improvement
            //这个用户所属的组织列表
            var userOrganizationsQuery = from userOrg in dbContext.Set<IdentityUserOrganizationUnit>()
                                         join ou in dbContext.OrganizationUnits.IncludeDetails(includeDetails) on userOrg.OrganizationUnitId equals ou.Id
                                         where userOrg.UserId == id
                                         select ou;
            IQueryable<IdentityRole> resultQuery;
            if (userOrganizationsQuery.Any())
            {
                //指定组织列表下的角色
                var orgUserRoleQuery = dbContext.Set<OrganizationUnitRole>()
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
        }
    }
}
