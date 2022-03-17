using Jh.Abp.EntityFrameworkCore;
using Jh.Abp.JhIdentity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace Jh.Abp.JhIdentity
{
    public class OrganizationUnitRepository : CrudRepository<IIdentityDbContext, OrganizationUnit, System.Guid>, IOrganizationUnitRepository
	{
        protected readonly IOrganizationUnitDapperRepository OrganizationUnitDapperRepository;
        public OrganizationUnitRepository(IDbContextProvider<IIdentityDbContext> dbContextProvider, IOrganizationUnitDapperRepository organizationunitDapperRepository) : base(dbContextProvider)
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
