
using Jh.Abp.Workflow.Localization;
using System;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
namespace Jh.Abp.Workflow
{
	public class JhAbpWorkflowPermissionDefinitionProvider: PermissionDefinitionProvider
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
		  var WorkflowEventSubscriptionsPermission = JhAbpWorkflowGroup.AddPermission(JhAbpWorkflowPermissions.WorkflowEventSubscriptions.Default, L("Permission:WorkflowEventSubscriptions"));
		 WorkflowEventSubscriptionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEventSubscriptions.Export, L("Permission:Export"));
		 WorkflowEventSubscriptionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEventSubscriptions.Detail, L("Permission:Detail"));
		 WorkflowEventSubscriptionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEventSubscriptions.Create, L("Permission:Create"));
		 WorkflowEventSubscriptionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEventSubscriptions.BatchCreate, L("Permission:BatchCreate"));
		 WorkflowEventSubscriptionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEventSubscriptions.Update, L("Permission:Edit"));
		 WorkflowEventSubscriptionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEventSubscriptions.PortionUpdate, L("Permission:PortionEdit"));
		 WorkflowEventSubscriptionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEventSubscriptions.Delete, L("Permission:Delete"));
		 WorkflowEventSubscriptionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEventSubscriptions.BatchDelete, L("Permission:BatchDelete"));
		 WorkflowEventSubscriptionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEventSubscriptions.Recover, L("Permission:Recover"));
		 WorkflowEventSubscriptionsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEventSubscriptions.ManagePermissions, L("Permission:ManagePermissions"));
		  var WorkflowEventsPermission = JhAbpWorkflowGroup.AddPermission(JhAbpWorkflowPermissions.WorkflowEvents.Default, L("Permission:WorkflowEvents"));
		 WorkflowEventsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEvents.Export, L("Permission:Export"));
		 WorkflowEventsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEvents.Detail, L("Permission:Detail"));
		 WorkflowEventsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEvents.Create, L("Permission:Create"));
		 WorkflowEventsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEvents.BatchCreate, L("Permission:BatchCreate"));
		 WorkflowEventsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEvents.Update, L("Permission:Edit"));
		 WorkflowEventsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEvents.PortionUpdate, L("Permission:PortionEdit"));
		 WorkflowEventsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEvents.Delete, L("Permission:Delete"));
		 WorkflowEventsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEvents.BatchDelete, L("Permission:BatchDelete"));
		 WorkflowEventsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEvents.Recover, L("Permission:Recover"));
		 WorkflowEventsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowEvents.ManagePermissions, L("Permission:ManagePermissions"));
		  var WorkflowExecutionErrorsPermission = JhAbpWorkflowGroup.AddPermission(JhAbpWorkflowPermissions.WorkflowExecutionErrors.Default, L("Permission:WorkflowExecutionErrors"));
		 WorkflowExecutionErrorsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionErrors.Export, L("Permission:Export"));
		 WorkflowExecutionErrorsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionErrors.Detail, L("Permission:Detail"));
		 WorkflowExecutionErrorsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionErrors.Create, L("Permission:Create"));
		 WorkflowExecutionErrorsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionErrors.BatchCreate, L("Permission:BatchCreate"));
		 WorkflowExecutionErrorsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionErrors.Update, L("Permission:Edit"));
		 WorkflowExecutionErrorsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionErrors.PortionUpdate, L("Permission:PortionEdit"));
		 WorkflowExecutionErrorsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionErrors.Delete, L("Permission:Delete"));
		 WorkflowExecutionErrorsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionErrors.BatchDelete, L("Permission:BatchDelete"));
		 WorkflowExecutionErrorsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionErrors.Recover, L("Permission:Recover"));
		 WorkflowExecutionErrorsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionErrors.ManagePermissions, L("Permission:ManagePermissions"));
		  var WorkflowExecutionPointersPermission = JhAbpWorkflowGroup.AddPermission(JhAbpWorkflowPermissions.WorkflowExecutionPointers.Default, L("Permission:WorkflowExecutionPointers"));
		 WorkflowExecutionPointersPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionPointers.Export, L("Permission:Export"));
		 WorkflowExecutionPointersPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionPointers.Detail, L("Permission:Detail"));
		 WorkflowExecutionPointersPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionPointers.Create, L("Permission:Create"));
		 WorkflowExecutionPointersPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionPointers.BatchCreate, L("Permission:BatchCreate"));
		 WorkflowExecutionPointersPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionPointers.Update, L("Permission:Edit"));
		 WorkflowExecutionPointersPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionPointers.PortionUpdate, L("Permission:PortionEdit"));
		 WorkflowExecutionPointersPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionPointers.Delete, L("Permission:Delete"));
		 WorkflowExecutionPointersPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionPointers.BatchDelete, L("Permission:BatchDelete"));
		 WorkflowExecutionPointersPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionPointers.Recover, L("Permission:Recover"));
		 WorkflowExecutionPointersPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExecutionPointers.ManagePermissions, L("Permission:ManagePermissions"));
		  var WorkflowExtensionAttributesPermission = JhAbpWorkflowGroup.AddPermission(JhAbpWorkflowPermissions.WorkflowExtensionAttributes.Default, L("Permission:WorkflowExtensionAttributes"));
		 WorkflowExtensionAttributesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExtensionAttributes.Export, L("Permission:Export"));
		 WorkflowExtensionAttributesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExtensionAttributes.Detail, L("Permission:Detail"));
		 WorkflowExtensionAttributesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExtensionAttributes.Create, L("Permission:Create"));
		 WorkflowExtensionAttributesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExtensionAttributes.BatchCreate, L("Permission:BatchCreate"));
		 WorkflowExtensionAttributesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExtensionAttributes.Update, L("Permission:Edit"));
		 WorkflowExtensionAttributesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExtensionAttributes.PortionUpdate, L("Permission:PortionEdit"));
		 WorkflowExtensionAttributesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExtensionAttributes.Delete, L("Permission:Delete"));
		 WorkflowExtensionAttributesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExtensionAttributes.BatchDelete, L("Permission:BatchDelete"));
		 WorkflowExtensionAttributesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExtensionAttributes.Recover, L("Permission:Recover"));
		 WorkflowExtensionAttributesPermission.AddChild(JhAbpWorkflowPermissions.WorkflowExtensionAttributes.ManagePermissions, L("Permission:ManagePermissions"));
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
		  var WorkflowScheduledCommandsPermission = JhAbpWorkflowGroup.AddPermission(JhAbpWorkflowPermissions.WorkflowScheduledCommands.Default, L("Permission:WorkflowScheduledCommands"));
		 WorkflowScheduledCommandsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowScheduledCommands.Export, L("Permission:Export"));
		 WorkflowScheduledCommandsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowScheduledCommands.Detail, L("Permission:Detail"));
		 WorkflowScheduledCommandsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowScheduledCommands.Create, L("Permission:Create"));
		 WorkflowScheduledCommandsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowScheduledCommands.BatchCreate, L("Permission:BatchCreate"));
		 WorkflowScheduledCommandsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowScheduledCommands.Update, L("Permission:Edit"));
		 WorkflowScheduledCommandsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowScheduledCommands.PortionUpdate, L("Permission:PortionEdit"));
		 WorkflowScheduledCommandsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowScheduledCommands.Delete, L("Permission:Delete"));
		 WorkflowScheduledCommandsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowScheduledCommands.BatchDelete, L("Permission:BatchDelete"));
		 WorkflowScheduledCommandsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowScheduledCommands.Recover, L("Permission:Recover"));
		 WorkflowScheduledCommandsPermission.AddChild(JhAbpWorkflowPermissions.WorkflowScheduledCommands.ManagePermissions, L("Permission:ManagePermissions"));
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
