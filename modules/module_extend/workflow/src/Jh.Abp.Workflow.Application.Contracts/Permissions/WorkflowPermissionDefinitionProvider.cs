using Jh.Abp.Workflow.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Jh.Abp.Workflow.Permissions;

public class WorkflowPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(WorkflowPermissions.GroupName, L("Permission:Workflow"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<WorkflowResource>(name);
    }
}
