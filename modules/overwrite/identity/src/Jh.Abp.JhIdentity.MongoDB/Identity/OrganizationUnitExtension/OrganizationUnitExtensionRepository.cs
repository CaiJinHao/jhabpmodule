using Jh.Abp.MongoDB;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;
using Volo.Abp.Identity;
using Volo.Abp.Identity.MongoDB;
using Volo.Abp.MongoDB;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Jh.Abp.Common;


namespace Jh.Abp.JhIdentity
{
	public class OrganizationUnitExtensionRepository : CrudRepository<IAbpIdentityMongoDbContext, OrganizationUnitExtension, System.Guid>, IOrganizationUnitExtensionRepository
	{
		 public OrganizationUnitExtensionRepository(IMongoDbContextProvider<IAbpIdentityMongoDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}
