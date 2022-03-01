using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Jh.Abp.JhMenu.MongoDB;

[ConnectionStringName(JhMenuDbProperties.ConnectionStringName)]
public interface IJhMenuMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
