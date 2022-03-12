
using System;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Jh.Abp.JhMenu.Localization;
namespace Jh.Abp.JhMenu
{
	public class JhMenuPermissionDefinitionProvider: PermissionDefinitionProvider
	{
	public override void Define(IPermissionDefinitionContext context)
	{
		var JhMenuGroup = context.AddGroup(JhMenuPermissions.GroupName, L("Permission:JhMenu"));
		  var MenuRoleMapsPermission = JhMenuGroup.AddPermission(JhMenuPermissions.MenuRoleMaps.Default, L("Permission:MenuRoleMaps"));
		 MenuRoleMapsPermission.AddChild(JhMenuPermissions.MenuRoleMaps.Create, L("Permission:Create"));
		 MenuRoleMapsPermission.AddChild(JhMenuPermissions.MenuRoleMaps.ManagePermissions, L("Permission:ManagePermissions"));
		  var MenusPermission = JhMenuGroup.AddPermission(JhMenuPermissions.Menus.Default, L("Permission:Menus"));
		 MenusPermission.AddChild(JhMenuPermissions.Menus.Detail, L("Permission:Detail"));
		 MenusPermission.AddChild(JhMenuPermissions.Menus.Create, L("Permission:Create"));
		 MenusPermission.AddChild(JhMenuPermissions.Menus.Update, L("Permission:Edit"));
		 MenusPermission.AddChild(JhMenuPermissions.Menus.Delete, L("Permission:Delete"));
		 MenusPermission.AddChild(JhMenuPermissions.Menus.BatchDelete, L("Permission:BatchDelete"));
		 MenusPermission.AddChild(JhMenuPermissions.Menus.Recover, L("Permission:Recover"));
		 MenusPermission.AddChild(JhMenuPermissions.Menus.ManagePermissions, L("Permission:ManagePermissions"));
		 //Write additional permission definitions
		 /*
"Permission:MenuRoleMaps": "角色菜单管理",
"Permission:Menus": "菜单管理",
		 */
	}
	 private static LocalizableString L(string name)
	{
		 return LocalizableString.Create<JhMenuResource>(name);
	}
	}
}
