using Volo.Abp.Reflection;

namespace Jh.Abp.Workflow.Permissions;

public class WorkflowPermissions
{
    public const string GroupName = "Workflow";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(WorkflowPermissions));
    }
}
