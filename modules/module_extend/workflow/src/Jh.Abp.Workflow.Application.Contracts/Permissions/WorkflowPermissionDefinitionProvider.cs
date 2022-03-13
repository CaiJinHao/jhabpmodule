
using System;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Jh.Abp.Workflow.Localization;
namespace Jh.Abp.Workflow
{
	public class WorkflowPermissionDefinitionProvider: PermissionDefinitionProvider
	{
	public override void Define(IPermissionDefinitionContext context)
	{
		var WorkflowGroup = context.AddGroup(WorkflowPermissions.GroupName, L("Permission:Workflow"));
		  var WorkflowBacklogsPermission = WorkflowGroup.AddPermission(WorkflowPermissions.WorkflowBacklogs.Default, L("Permission:WorkflowBacklogs"));
		 WorkflowBacklogsPermission.AddChild(WorkflowPermissions.WorkflowBacklogs.Detail, L("Permission:Detail"));
		 WorkflowBacklogsPermission.AddChild(WorkflowPermissions.WorkflowBacklogs.Create, L("Permission:Create"));
		 WorkflowBacklogsPermission.AddChild(WorkflowPermissions.WorkflowBacklogs.Update, L("Permission:Edit"));
		 WorkflowBacklogsPermission.AddChild(WorkflowPermissions.WorkflowBacklogs.Delete, L("Permission:Delete"));
		 WorkflowBacklogsPermission.AddChild(WorkflowPermissions.WorkflowBacklogs.BatchDelete, L("Permission:BatchDelete"));
		 WorkflowBacklogsPermission.AddChild(WorkflowPermissions.WorkflowBacklogs.Recover, L("Permission:Recover"));
		 WorkflowBacklogsPermission.AddChild(WorkflowPermissions.WorkflowBacklogs.ManagePermissions, L("Permission:ManagePermissions"));
		  var WorkflowDefinitionsPermission = WorkflowGroup.AddPermission(WorkflowPermissions.WorkflowDefinitions.Default, L("Permission:WorkflowDefinitions"));
		 WorkflowDefinitionsPermission.AddChild(WorkflowPermissions.WorkflowDefinitions.Detail, L("Permission:Detail"));
		 WorkflowDefinitionsPermission.AddChild(WorkflowPermissions.WorkflowDefinitions.Create, L("Permission:Create"));
		 WorkflowDefinitionsPermission.AddChild(WorkflowPermissions.WorkflowDefinitions.Update, L("Permission:Edit"));
		 WorkflowDefinitionsPermission.AddChild(WorkflowPermissions.WorkflowDefinitions.Delete, L("Permission:Delete"));
		 WorkflowDefinitionsPermission.AddChild(WorkflowPermissions.WorkflowDefinitions.BatchDelete, L("Permission:BatchDelete"));
		 WorkflowDefinitionsPermission.AddChild(WorkflowPermissions.WorkflowDefinitions.Recover, L("Permission:Recover"));
		 WorkflowDefinitionsPermission.AddChild(WorkflowPermissions.WorkflowDefinitions.ManagePermissions, L("Permission:ManagePermissions"));
		  var WorkflowInstancesPermission = WorkflowGroup.AddPermission(WorkflowPermissions.WorkflowInstances.Default, L("Permission:WorkflowInstances"));
		 WorkflowInstancesPermission.AddChild(WorkflowPermissions.WorkflowInstances.Detail, L("Permission:Detail"));
		 WorkflowInstancesPermission.AddChild(WorkflowPermissions.WorkflowInstances.Create, L("Permission:Create"));
		 WorkflowInstancesPermission.AddChild(WorkflowPermissions.WorkflowInstances.Update, L("Permission:Edit"));
		 WorkflowInstancesPermission.AddChild(WorkflowPermissions.WorkflowInstances.Delete, L("Permission:Delete"));
		 WorkflowInstancesPermission.AddChild(WorkflowPermissions.WorkflowInstances.BatchDelete, L("Permission:BatchDelete"));
		 WorkflowInstancesPermission.AddChild(WorkflowPermissions.WorkflowInstances.Recover, L("Permission:Recover"));
		 WorkflowInstancesPermission.AddChild(WorkflowPermissions.WorkflowInstances.ManagePermissions, L("Permission:ManagePermissions"));
		 //Write additional permission definitions
		 /*
"Permission:WorkflowBacklogs": "待办事项管理",
"Permission:WorkflowDefinitions": "工作流定义管理",
"Permission:WorkflowInstances": "工作流实例管理",
		 */
	}
	 private static LocalizableString L(string name)
	{
		 return LocalizableString.Create<WorkflowResource>(name);
	}
	}
}
