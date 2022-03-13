
using System;
using Volo.Abp.Reflection;
namespace Jh.Abp.Workflow
{
	public class WorkflowPermissions
	{
		public const string GroupName = "Workflow";
	public class WorkflowBacklogs 
	{
		public const string Default = GroupName + ".WorkflowBacklogs";
		public const string Detail = Default + ".Detail";
		public const string Create = Default + ".Create";
		public const string Update = Default + ".Update";
		public const string Delete = Default + ".Delete";
		public const string BatchDelete = Default + ".BatchDelete";
		public const string Recover = Default + ".Recover";
		public const string ManagePermissions = Default + ".ManagePermissions";
	}
	public class WorkflowDefinitions 
	{
		public const string Default = GroupName + ".WorkflowDefinitions";
		public const string Detail = Default + ".Detail";
		public const string Create = Default + ".Create";
		public const string Update = Default + ".Update";
		public const string Delete = Default + ".Delete";
		public const string BatchDelete = Default + ".BatchDelete";
		public const string Recover = Default + ".Recover";
		public const string ManagePermissions = Default + ".ManagePermissions";
	}
	public class WorkflowInstances 
	{
		public const string Default = GroupName + ".WorkflowInstances";
		public const string Detail = Default + ".Detail";
		public const string Create = Default + ".Create";
		public const string Update = Default + ".Update";
		public const string Delete = Default + ".Delete";
		public const string BatchDelete = Default + ".BatchDelete";
		public const string Recover = Default + ".Recover";
		public const string ManagePermissions = Default + ".ManagePermissions";
	}
	public static string[] GetAll()
	{
		return ReflectionHelper.GetPublicConstantsRecursively(typeof(WorkflowPermissions));
	}
	}
}
