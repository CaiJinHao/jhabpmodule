
using Jh.Abp.MongoDB;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.MongoDB;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.MongoDB;

namespace Jh.Abp.TenantManagement
{
    public class TenantRepository : CrudRepository<ITenantManagementMongoDbContext, Tenant, System.Guid>, ITenantRepository
    {
        public TenantRepository(IMongoDbContextProvider<ITenantManagementMongoDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}
