using Jh.Abp.JhIdentity.MongoDB;
using Jh.Abp.MongoDB;
using Volo.Abp.MongoDB;

namespace Jh.Abp.JhIdentity
{
    public class OrganizationUnitExtensionRepository : CrudRepository<JhIdentityMongoDbContext, OrganizationUnitExtension, System.Guid>, IOrganizationUnitExtensionRepository
	{
        public OrganizationUnitExtensionRepository(IMongoDbContextProvider<JhIdentityMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
	}
}
