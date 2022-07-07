
using Jh.Abp.JhIdentity.EntityFrameworkCore;
using Jh.Abp.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace Jh.Abp.TenantManagement
{
	public class TenantRepository : CrudRepository<ITenantManagementDbContext, Tenant, System.Guid>, ITenantRepository
	{
		 public TenantRepository(IDbContextProvider<ITenantManagementDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
