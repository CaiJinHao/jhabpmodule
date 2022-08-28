using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Jh.Abp.JhIdentity.MongoDB;

[ConnectionStringName(JhIdentityDbProperties.ConnectionStringName)]
public interface IJhIdentityMongoDbContext : IAbpMongoDbContext
{
    IMongoCollection<OrganizationUnitExtension> OrganizationUnitExtensions { get; }
}
