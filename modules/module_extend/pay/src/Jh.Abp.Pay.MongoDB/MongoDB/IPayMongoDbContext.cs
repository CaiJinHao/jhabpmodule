using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Jh.Abp.Pay.MongoDB;

[ConnectionStringName(PayDbProperties.ConnectionStringName)]
public interface IPayMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
