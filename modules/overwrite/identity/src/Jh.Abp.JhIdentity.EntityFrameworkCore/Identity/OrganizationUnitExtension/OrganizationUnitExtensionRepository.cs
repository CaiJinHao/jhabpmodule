
using Jh.Abp.JhIdentity.EntityFrameworkCore;
using Jh.Abp.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
namespace Jh.Abp.JhIdentity
{
	public class OrganizationUnitExtensionRepository : CrudRepository<JhIdentityDbContext, OrganizationUnitExtension, System.Guid>, IOrganizationUnitExtensionRepository
	{
		 public OrganizationUnitExtensionRepository(IDbContextProvider<JhIdentityDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
