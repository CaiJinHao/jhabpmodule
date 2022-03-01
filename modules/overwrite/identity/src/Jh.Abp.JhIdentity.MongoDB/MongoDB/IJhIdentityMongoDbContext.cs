using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Jh.Abp.JhIdentity.MongoDB;

[ConnectionStringName(JhIdentityDbProperties.ConnectionStringName)]
public interface IJhIdentityMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
