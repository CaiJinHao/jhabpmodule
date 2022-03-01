using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Jh.Abp.JhMenu.MongoDB;

[ConnectionStringName(JhMenuDbProperties.ConnectionStringName)]
public class JhMenuMongoDbContext : AbpMongoDbContext, IJhMenuMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureJhMenu();
    }
}
