using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Jh.Abp.JhPermission.MongoDB;

[ConnectionStringName(JhPermissionDbProperties.ConnectionStringName)]
public class JhPermissionMongoDbContext : AbpMongoDbContext, IJhPermissionMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureJhPermission();
    }
}
