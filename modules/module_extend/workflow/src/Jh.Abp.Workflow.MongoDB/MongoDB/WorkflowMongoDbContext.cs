using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Jh.Abp.Workflow.MongoDB;

[ConnectionStringName(WorkflowDbProperties.ConnectionStringName)]
public class WorkflowMongoDbContext : AbpMongoDbContext, IWorkflowMongoDbContext
{
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureWorkflow();
    }
}
