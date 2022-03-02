using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Jh.Abp.Workflow.MongoDB;

[ConnectionStringName(WorkflowDbProperties.ConnectionStringName)]
public interface IWorkflowMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
