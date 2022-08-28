using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Jh.Abp.JhIdentity.MongoDB;

[ConnectionStringName(JhIdentityDbProperties.ConnectionStringName)]
public class JhIdentityMongoDbContext : AbpMongoDbContext, IJhIdentityMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */
    public IMongoCollection<OrganizationUnitExtension> OrganizationUnitExtensions => Collection<OrganizationUnitExtension>();
    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureJhIdentity();
    }
}
