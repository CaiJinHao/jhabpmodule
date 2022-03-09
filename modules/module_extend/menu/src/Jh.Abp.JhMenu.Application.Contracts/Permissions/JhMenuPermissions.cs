
using System;
using Volo.Abp.Reflection;
namespace Jh.Abp.JhMenu
{
	public class JhMenuPermissions
	{
		public const string GroupName = "JhMenu";
	public class MenuRoleMaps 
	{
		public const string Default = GroupName + ".MenuRoleMaps";
		public const string Detail = Default + ".Detail";
		public const string Create = Default + ".Create";
		public const string Update = Default + ".Update";
		public const string Delete = Default + ".Delete";
		public const string BatchDelete = Default + ".BatchDelete";
		public const string Recover = Default + ".Recover";
		public const string ManagePermissions = Default + ".ManagePermissions";
	}
	public class Menus 
	{
		public const string Default = GroupName + ".Menus";
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
		return ReflectionHelper.GetPublicConstantsRecursively(typeof(JhMenuPermissions));
	}
	}
}
