using Volo.Abp.Identity;
using Volo.Abp.Reflection;

namespace Jh.Abp.JhIdentity;

public class JhIdentityPermissions
{
    public const string GroupName = IdentityPermissions.GroupName;

    public class JhPermissions
    {
        public const string Default = GroupName + ".JhPermissions";
        public const string Detail = Default + ".Detail";
        public const string Update = Default + ".Update";
        public const string ManagePermissions = Default + ".ManagePermissions";
    }

    public class OrganizationUnits
    {
        public const string Default = GroupName + ".OrganizationUnits";
        public const string Detail = Default + ".Detail";
        public const string Create = Default + ".Create";
        public const string Update = Default + ".Update";
        public const string Delete = Default + ".Delete";
        public const string BatchDelete = Default + ".BatchDelete";
        public const string Recover = Default + ".Recover";
        public const string ManagePermissions = Default + ".ManagePermissions";
    }

    public class IdentityUsers
    {
        //使用原有得权限
        public const string Default = IdentityPermissions.Users.Default;
        public const string Create = IdentityPermissions.Users.Create;
        public const string Update = IdentityPermissions.Users.Update;
        public const string Delete = IdentityPermissions.Users.Delete;
        public const string ManagePermissions = IdentityPermissions.Users.ManagePermissions;

        public const string Detail = Default + ".Detail";
        public const string BatchDelete = Default + ".BatchDelete";
        public const string Recover = Default + ".Recover";
    }

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(JhIdentityPermissions));
    }
}
