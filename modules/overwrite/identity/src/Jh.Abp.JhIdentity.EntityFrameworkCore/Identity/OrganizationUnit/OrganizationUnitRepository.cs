using Jh.Abp.EntityFrameworkCore.Extensions;
using Jh.Abp.JhIdentity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace Jh.Abp.JhIdentity
{
	public class OrganizationUnitRepository : CrudRepository<JhIdentityDbContext, OrganizationUnit, System.Guid>, IOrganizationUnitRepository
	{
        protected readonly IOrganizationUnitDapperRepository OrganizationUnitDapperRepository;
        public OrganizationUnitRepository(IDbContextProvider<JhIdentityDbContext> dbContextProvider, IOrganizationUnitDapperRepository organizationunitDapperRepository) : base(dbContextProvider)
        {
            OrganizationUnitDapperRepository = organizationunitDapperRepository;
        }

        public override async Task<IQueryable<OrganizationUnit>> WithDetailsAsync()
        {
            var query = await GetQueryableAsync();
            return query.Include(x => x.Roles);
        }
    }
}
