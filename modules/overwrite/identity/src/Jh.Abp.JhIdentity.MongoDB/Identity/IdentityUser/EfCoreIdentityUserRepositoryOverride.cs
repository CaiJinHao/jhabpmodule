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
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Jh.Abp.JhIdentity
{
    [Dependency(ReplaceServices = true)]
    [ExposeServices(typeof(Volo.Abp.Identity.IIdentityUserRepository),typeof(MongoIdentityUserRepository))]
    public class EMongoIdentityUserRepositoryOverride : MongoIdentityUserRepository
    {
        public EMongoIdentityUserRepositoryOverride(IMongoDbContextProvider<IAbpIdentityMongoDbContext> dbContextProvider) : base(dbContextProvider)
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
            var userRoleIds = await GetUserRoleIdsAsync(id, cancellationToken);
            return await (await GetMongoQueryableAsync<IdentityRole>()).Where(a => userRoleIds.Contains(a.Id)).Select(a => a.Name).ToListAsync();
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
            var userRoleIds = await GetUserRoleIdsAsync(id,cancellationToken);
            return await (await GetMongoQueryableAsync<IdentityRole>()).Where(a => userRoleIds.Contains(a.Id)).ToListAsync();
        }

        private async Task<Guid[]> GetUserRoleIdsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var user = await GetAsync(id, cancellationToken: cancellationToken);
            //用户所属的角色
            var userRoleIds = user.Roles.Select(a => a.RoleId).ToArray();
            //这个用户所属的组织列表
            var userOrganizationUnitIds = user.OrganizationUnits.Select(a => a.OrganizationUnitId);
            if (userOrganizationUnitIds.Any())
            {
                //指定组织列表下的角色
                var organizationUnit = await (await GetMongoQueryableAsync<OrganizationUnit>()).Where(a => userOrganizationUnitIds.Contains(a.Id)).ToListAsync();
                userRoleIds = organizationUnit.SelectMany(a => a.Roles).Select(a => a.RoleId).Where(a => userRoleIds.Contains(a)).ToArray();
            }
            return userRoleIds;
        }
    }
}
