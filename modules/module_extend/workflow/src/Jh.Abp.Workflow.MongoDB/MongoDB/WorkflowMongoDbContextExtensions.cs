using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Jh.Abp.Workflow.MongoDB;

public static class WorkflowMongoDbContextExtensions
{
    public static void ConfigureWorkflow(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
