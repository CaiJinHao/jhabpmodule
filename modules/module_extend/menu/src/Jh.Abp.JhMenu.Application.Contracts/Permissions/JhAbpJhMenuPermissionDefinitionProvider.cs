
using Jh.Abp.JhMenu.Localization;
using System;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
namespace Jh.Abp.JhMenu
{
	public class JhAbpJhMenuPermissionDefinitionProvider: PermissionDefinitionProvider
	{
	public override void Define(IPermissionDefinitionContext context)
	{
		var JhAbpJhMenuGroup = context.AddGroup(JhAbpJhMenuPermissions.GroupName, L("Permission:JhAbpJhMenu"));
		  var MenuRoleMapsPermission = JhAbpJhMenuGroup.AddPermission(JhAbpJhMenuPermissions.MenuRoleMaps.Default, L("Permission:MenuRoleMap"));
		 MenuRoleMapsPermission.AddChild(JhAbpJhMenuPermissions.MenuRoleMaps.Export, L("Permission:Export"));
		 MenuRoleMapsPermission.AddChild(JhAbpJhMenuPermissions.MenuRoleMaps.Detail, L("Permission:Detail"));
		 MenuRoleMapsPermission.AddChild(JhAbpJhMenuPermissions.MenuRoleMaps.Create, L("Permission:Create"));
		 MenuRoleMapsPermission.AddChild(JhAbpJhMenuPermissions.MenuRoleMaps.BatchCreate, L("Permission:BatchCreate"));
		 MenuRoleMapsPermission.AddChild(JhAbpJhMenuPermissions.MenuRoleMaps.Update, L("Permission:Edit"));
		 MenuRoleMapsPermission.AddChild(JhAbpJhMenuPermissions.MenuRoleMaps.PortionUpdate, L("Permission:PortionEdit"));
		 MenuRoleMapsPermission.AddChild(JhAbpJhMenuPermissions.MenuRoleMaps.Delete, L("Permission:Delete"));
		 MenuRoleMapsPermission.AddChild(JhAbpJhMenuPermissions.MenuRoleMaps.BatchDelete, L("Permission:BatchDelete"));
		 MenuRoleMapsPermission.AddChild(JhAbpJhMenuPermissions.MenuRoleMaps.Recover, L("Permission:Recover"));
		 MenuRoleMapsPermission.AddChild(JhAbpJhMenuPermissions.MenuRoleMaps.ManagePermissions, L("Permission:ManagePermissions"));
		  var MenusPermission = JhAbpJhMenuGroup.AddPermission(JhAbpJhMenuPermissions.Menus.Default, L("Permission:Menu"));
		 MenusPermission.AddChild(JhAbpJhMenuPermissions.Menus.Export, L("Permission:Export"));
		 MenusPermission.AddChild(JhAbpJhMenuPermissions.Menus.Detail, L("Permission:Detail"));
		 MenusPermission.AddChild(JhAbpJhMenuPermissions.Menus.Create, L("Permission:Create"));
		 MenusPermission.AddChild(JhAbpJhMenuPermissions.Menus.BatchCreate, L("Permission:BatchCreate"));
		 MenusPermission.AddChild(JhAbpJhMenuPermissions.Menus.Update, L("Permission:Edit"));
		 MenusPermission.AddChild(JhAbpJhMenuPermissions.Menus.PortionUpdate, L("Permission:PortionEdit"));
		 MenusPermission.AddChild(JhAbpJhMenuPermissions.Menus.Delete, L("Permission:Delete"));
		 MenusPermission.AddChild(JhAbpJhMenuPermissions.Menus.BatchDelete, L("Permission:BatchDelete"));
		 MenusPermission.AddChild(JhAbpJhMenuPermissions.Menus.Recover, L("Permission:Recover"));
		 MenusPermission.AddChild(JhAbpJhMenuPermissions.Menus.ManagePermissions, L("Permission:ManagePermissions"));
		 //Write additional permission definitions
		 /*
"Permission:MenuRoleMap": "菜单角色中间表",
"Permission:Menu": "菜单",
		 */
	}
	 private static LocalizableString L(string name)
	{
		 return LocalizableString.Create<JhMenuResource>(name);
	}
	}
}
