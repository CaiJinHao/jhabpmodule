namespace Jh.Abp.Workflow;

public static class WorkflowDbProperties
{
    public static string DbTablePrefix { get; set; } = "Workflow";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Workflow";
}
