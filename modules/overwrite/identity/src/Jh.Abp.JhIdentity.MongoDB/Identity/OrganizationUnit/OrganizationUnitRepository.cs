using Jh.Abp.MongoDB;
using Volo.Abp.Identity;
using Volo.Abp.Identity.MongoDB;
using Volo.Abp.MongoDB;

namespace Jh.Abp.JhIdentity
{
    public class OrganizationUnitRepository : CrudRepository<IAbpIdentityMongoDbContext, OrganizationUnit, System.Guid>, IOrganizationUnitRepository
    {
        public OrganizationUnitRepository(IMongoDbContextProvider<IAbpIdentityMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
