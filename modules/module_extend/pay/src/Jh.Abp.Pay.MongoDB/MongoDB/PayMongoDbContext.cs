using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Jh.Abp.Pay.MongoDB;

[ConnectionStringName(PayDbProperties.ConnectionStringName)]
public class PayMongoDbContext : AbpMongoDbContext, IPayMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigurePay();
    }
}
