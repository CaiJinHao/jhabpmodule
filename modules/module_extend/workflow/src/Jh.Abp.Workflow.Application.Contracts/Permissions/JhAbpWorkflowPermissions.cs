
using System;
using Volo.Abp.Reflection;
namespace Jh.Abp.Workflow
{
	public class JhAbpWorkflowPermissions
	{
		public const string GroupName = "JhAbpWorkflow";
	public class Backlogs 
	{
		public const string Default = GroupName + ".Backlogs";
		public const string Export = Default + ".Export";
		public const string Detail = Default + ".Detail";
		public const string Create = Default + ".Create";
		public const string BatchCreate = Default + ".BatchCreate";
		public const string Update = Default + ".Update";
		public const string PortionUpdate = Default + ".PortionUpdate";
		public const string Delete = Default + ".Delete";
		public const string BatchDelete = Default + ".BatchDelete";
		public const string Recover = Default + ".Recover";
		public const string ManagePermissions = Default + ".ManagePermissions";
	}
	public class WorkflowDefinitions 
	{
		public const string Default = GroupName + ".WorkflowDefinitions";
		public const string Export = Default + ".Export";
		public const string Detail = Default + ".Detail";
		public const string Create = Default + ".Create";
		public const string BatchCreate = Default + ".BatchCreate";
		public const string Update = Default + ".Update";
		public const string PortionUpdate = Default + ".PortionUpdate";
		public const string Delete = Default + ".Delete";
		public const string BatchDelete = Default + ".BatchDelete";
		public const string Recover = Default + ".Recover";
		public const string ManagePermissions = Default + ".ManagePermissions";
	}
	public class WorkflowEventSubscriptions 
	{
		public const string Default = GroupName + ".WorkflowEventSubscriptions";
		public const string Export = Default + ".Export";
		public const string Detail = Default + ".Detail";
		public const string Create = Default + ".Create";
		public const string BatchCreate = Default + ".BatchCreate";
		public const string Update = Default + ".Update";
		public const string PortionUpdate = Default + ".PortionUpdate";
		public const string Delete = Default + ".Delete";
		public const string BatchDelete = Default + ".BatchDelete";
		public const string Recover = Default + ".Recover";
		public const string ManagePermissions = Default + ".ManagePermissions";
	}
	public class WorkflowEvents 
	{
		public const string Default = GroupName + ".WorkflowEvents";
		public const string Export = Default + ".Export";
		public const string Detail = Default + ".Detail";
		public const string Create = Default + ".Create";
		public const string BatchCreate = Default + ".BatchCreate";
		public const string Update = Default + ".Update";
		public const string PortionUpdate = Default + ".PortionUpdate";
		public const string Delete = Default + ".Delete";
		public const string BatchDelete = Default + ".BatchDelete";
		public const string Recover = Default + ".Recover";
		public const string ManagePermissions = Default + ".ManagePermissions";
	}
	public class WorkflowExecutionErrors 
	{
		public const string Default = GroupName + ".WorkflowExecutionErrors";
		public const string Export = Default + ".Export";
		public const string Detail = Default + ".Detail";
		public const string Create = Default + ".Create";
		public const string BatchCreate = Default + ".BatchCreate";
		public const string Update = Default + ".Update";
		public const string PortionUpdate = Default + ".PortionUpdate";
		public const string Delete = Default + ".Delete";
		public const string BatchDelete = Default + ".BatchDelete";
		public const string Recover = Default + ".Recover";
		public const string ManagePermissions = Default + ".ManagePermissions";
	}
	public class WorkflowExecutionPointers 
	{
		public const string Default = GroupName + ".WorkflowExecutionPointers";
		public const string Export = Default + ".Export";
		public const string Detail = Default + ".Detail";
		public const string Create = Default + ".Create";
		public const string BatchCreate = Default + ".BatchCreate";
		public const string Update = Default + ".Update";
		public const string PortionUpdate = Default + ".PortionUpdate";
		public const string Delete = Default + ".Delete";
		public const string BatchDelete = Default + ".BatchDelete";
		public const string Recover = Default + ".Recover";
		public const string ManagePermissions = Default + ".ManagePermissions";
	}
	public class WorkflowExtensionAttributes 
	{
		public const string Default = GroupName + ".WorkflowExtensionAttributes";
		public const string Export = Default + ".Export";
		public const string Detail = Default + ".Detail";
		public const string Create = Default + ".Create";
		public const string BatchCreate = Default + ".BatchCreate";
		public const string Update = Default + ".Update";
		public const string PortionUpdate = Default + ".PortionUpdate";
		public const string Delete = Default + ".Delete";
		public const string BatchDelete = Default + ".BatchDelete";
		public const string Recover = Default + ".Recover";
		public const string ManagePermissions = Default + ".ManagePermissions";
	}
	public class WorkflowInstances 
	{
		public const string Default = GroupName + ".WorkflowInstances";
		public const string Export = Default + ".Export";
		public const string Detail = Default + ".Detail";
		public const string Create = Default + ".Create";
		public const string BatchCreate = Default + ".BatchCreate";
		public const string Update = Default + ".Update";
		public const string PortionUpdate = Default + ".PortionUpdate";
		public const string Delete = Default + ".Delete";
		public const string BatchDelete = Default + ".BatchDelete";
		public const string Recover = Default + ".Recover";
		public const string ManagePermissions = Default + ".ManagePermissions";
	}
	public class WorkflowScheduledCommands 
	{
		public const string Default = GroupName + ".WorkflowScheduledCommands";
		public const string Export = Default + ".Export";
		public const string Detail = Default + ".Detail";
		public const string Create = Default + ".Create";
		public const string BatchCreate = Default + ".BatchCreate";
		public const string Update = Default + ".Update";
		public const string PortionUpdate = Default + ".PortionUpdate";
		public const string Delete = Default + ".Delete";
		public const string BatchDelete = Default + ".BatchDelete";
		public const string Recover = Default + ".Recover";
		public const string ManagePermissions = Default + ".ManagePermissions";
	}
	public static string[] GetAll()
	{
		return ReflectionHelper.GetPublicConstantsRecursively(typeof(JhAbpWorkflowPermissions));
	}
	}
}
