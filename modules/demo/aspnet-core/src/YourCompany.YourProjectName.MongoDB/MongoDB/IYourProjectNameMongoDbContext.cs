using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace YourCompany.YourProjectName.MongoDB;

[ConnectionStringName(YourProjectNameDbProperties.ConnectionStringName)]
public interface IYourProjectNameMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
