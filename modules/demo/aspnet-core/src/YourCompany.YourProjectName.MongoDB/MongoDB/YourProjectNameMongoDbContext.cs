using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace YourCompany.YourProjectName.MongoDB;

[ConnectionStringName(YourProjectNameDbProperties.ConnectionStringName)]
public class YourProjectNameMongoDbContext : AbpMongoDbContext, IYourProjectNameMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureYourProjectName();
    }
}
