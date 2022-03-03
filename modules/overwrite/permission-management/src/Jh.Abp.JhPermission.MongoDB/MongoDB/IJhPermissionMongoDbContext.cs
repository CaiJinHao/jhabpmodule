using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Jh.Abp.JhPermission.MongoDB;

[ConnectionStringName(JhPermissionDbProperties.ConnectionStringName)]
public interface IJhPermissionMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
