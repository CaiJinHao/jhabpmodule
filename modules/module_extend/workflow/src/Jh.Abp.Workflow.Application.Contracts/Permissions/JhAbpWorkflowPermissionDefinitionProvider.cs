
using Jh.Abp.Workflow.Localization;
using System;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
namespace Jh.Abp.Workflow
{
    public class JhAbpWorkflowPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var JhAbpWorkflowGroup = context.AddGroup(JhAbpWorkflowPermissions.GroupName, L("Permission:JhAbpWorkflow"));
            var BacklogsPermission = JhAbpWorkflowGroup.AddPermission(JhAbpWorkflowPermissions.Backlogs.Default, L("Permission:Backlogs"));
            BacklogsPermission.AddChild(JhAbpWorkflowPermissions.Backlogs.Export, L("Permission:Export"));
            BacklogsPermission.AddChild(JhAbpWorkflowPermissions.Backlogs.Detail, L("Permission:Detail"));
            BacklogsPermission.AddChild(JhAbpWorkflowPermissions.Backlogs.Create, L("Permission:Create"));
            BacklogsPermission.AddChild(JhAbpWorkflowPermissions.Backlogs.BatchCreate, L("Permission:BatchCreate"));
            BacklogsPermission.AddChild(JhAbpWorkflowPermissions.Backlogs.Update, L("Permission:Edit"));
            BacklogsPermission.AddChild(JhAbpWorkflowPermissions.Backlogs.PortionUpdate, L("Permission:PortionEdit"));
            BacklogsPermission.AddChild(JhAbpWorkflowPermissions.Backlogs.Delete, L("Permission:Delete"));
            BacklogsPermission.AddChild(JhAbpWorkflowPermissions.Backlogs.BatchDelete, L("Permission:BatchDelete"));
            BacklogsPermission.AddChild(JhAbpWorkflowPermissions.Backlogs.Recover, L("Permission:Recover"));
            BacklogsPermission.AddChild(JhAbpWorkflowPermissions.Backlogs.ManagePermissions, L("Permission:ManagePermissions"));
            var WorkflowDefinitionsPermission = JhAbpWorkflowGroup.AddPermission(JhAbpWorkflowPermissions.WorkflowDefinitions.Default, L("Permission:WorkflowDefinitions"));
            WorkflowDefinitionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowDefinitions.Export, L("Permission:Export"));
            WorkflowDefinitionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowDefinitions.Detail, L("Permission:Detail"));
            WorkflowDefinitionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowDefinitions.Create, L("Permission:Create"));
            WorkflowDefinitionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowDefinitions.BatchCreate, L("Permission:BatchCreate"));
            WorkflowDefinitionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowDefinitions.Update, L("Permission:Edit"));
            WorkflowDefinitionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowDefinitions.PortionUpdate, L("Permission:PortionEdit"));
            WorkflowDefinitionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowDefinitions.Delete, L("Permission:Delete"));
            WorkflowDefinitionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowDefinitions.BatchDelete, L("Permission:BatchDelete"));
            WorkflowDefinitionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowDefinitions.Recover, L("Permission:Recover"));
            WorkflowDefinitionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowDefinitions.ManagePermissions, L("Permission:ManagePermissions"));

            var WorkflowInstancesPermission = JhAbpWorkflowGroup.AddPermission(JhAbpWorkflowPermissions.WorkflowInstances.Default, L("Permission:WorkflowInstances"));
            WorkflowInstancesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowInstances.Export, L("Permission:Export"));
            WorkflowInstancesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowInstances.Detail, L("Permission:Detail"));
            WorkflowInstancesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowInstances.Create, L("Permission:Create"));
            WorkflowInstancesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowInstances.BatchCreate, L("Permission:BatchCreate"));
            WorkflowInstancesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowInstances.Update, L("Permission:Edit"));
            WorkflowInstancesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowInstances.PortionUpdate, L("Permission:PortionEdit"));
            WorkflowInstancesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowInstances.Delete, L("Permission:Delete"));
            WorkflowInstancesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowInstances.BatchDelete, L("Permission:BatchDelete"));
            WorkflowInstancesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowInstances.Recover, L("Permission:Recover"));
            WorkflowInstancesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowInstances.ManagePermissions, L("Permission:ManagePermissions"));

            //Write additional permission definitions
            /*
   "Permission:Backlogs": "待办事项",
   "Permission:WorkflowDefinitions": "工作流定义",
   "Permission:WorkflowEventSubscriptions": "订阅事件",
   "Permission:WorkflowEvents": "事件",
   "Permission:WorkflowExecutionErrors": "执行错误",
   "Permission:WorkflowExecutionPointers": "执行节点",
   "Permission:WorkflowExtensionAttributes": "扩展属性",
   "Permission:WorkflowInstances": "工作流实例",
   "Permission:WorkflowScheduledCommands": "",
            */
        }
        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<WorkflowResource>(name);
        }
    }
}
