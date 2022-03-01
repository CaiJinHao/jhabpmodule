using Volo.Abp.Reflection;

namespace Jh.Abp.JhIdentity;

public class JhIdentityPermissions
{
    public const string GroupName = "JhIdentity";

    public class OrganizationUnits
    {
        public const string Default = GroupName + ".OrganizationUnits";
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
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(JhIdentityPermissions));
    }
}
