﻿using Jh.Abp.JhIdentity.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Jh.Abp.JhIdentity.Permissions;

public class JhIdentityPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var JhIdentityGroup = context.AddGroup(JhIdentityPermissions.GroupName, L("Permission:JhIdentity"));
		var OrganizationUnitsPermission = JhIdentityGroup.AddPermission(JhIdentityPermissions.OrganizationUnits.Default, L("Permission:OrganizationUnits"));
		OrganizationUnitsPermission.AddChild(JhIdentityPermissions.OrganizationUnits.Detail, L("Permission:Detail"));
		OrganizationUnitsPermission.AddChild(JhIdentityPermissions.OrganizationUnits.Create, L("Permission:Create"));
		OrganizationUnitsPermission.AddChild(JhIdentityPermissions.OrganizationUnits.Update, L("Permission:Edit"));
		OrganizationUnitsPermission.AddChild(JhIdentityPermissions.OrganizationUnits.Delete, L("Permission:Delete"));
		OrganizationUnitsPermission.AddChild(JhIdentityPermissions.OrganizationUnits.BatchDelete, L("Permission:BatchDelete"));
		OrganizationUnitsPermission.AddChild(JhIdentityPermissions.OrganizationUnits.Recover, L("Permission:Recover"));
		OrganizationUnitsPermission.AddChild(JhIdentityPermissions.OrganizationUnits.ManagePermissions, L("Permission:ManagePermissions"));

		var IdentityUsersPermission = JhIdentityGroup.AddPermission(JhIdentityPermissions.IdentityUsers.Default, L("Permission:IdentityUsers"));
		IdentityUsersPermission.AddChild(JhIdentityPermissions.IdentityUsers.Detail, L("Permission:Detail"));
		IdentityUsersPermission.AddChild(JhIdentityPermissions.IdentityUsers.Create, L("Permission:Create"));
		IdentityUsersPermission.AddChild(JhIdentityPermissions.IdentityUsers.Update, L("Permission:Edit"));
		IdentityUsersPermission.AddChild(JhIdentityPermissions.IdentityUsers.Delete, L("Permission:Delete"));
		IdentityUsersPermission.AddChild(JhIdentityPermissions.IdentityUsers.BatchDelete, L("Permission:BatchDelete"));
		IdentityUsersPermission.AddChild(JhIdentityPermissions.IdentityUsers.Recover, L("Permission:Recover"));
		IdentityUsersPermission.AddChild(JhIdentityPermissions.IdentityUsers.ManagePermissions, L("Permission:ManagePermissions"));

	}

	private static LocalizableString L(string name)
    {
        return LocalizableString.Create<JhIdentityResource>(name);
    }
}
