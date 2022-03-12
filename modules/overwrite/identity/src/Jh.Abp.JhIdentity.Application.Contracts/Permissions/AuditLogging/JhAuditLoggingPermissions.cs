using Volo.Abp.Reflection;

namespace Jh.Abp.JhAuditLogging.Permissions
{
    public class JhAuditLoggingPermissions
    {
        public const string GroupName = "JhAuditLogging";
        public static class AuditLoggings
        {
            public const string Default = GroupName + ".AuditLoggings";
            public const string Detail = Default + ".Detail";
            public const string Delete = Default + ".Delete";
            public const string BatchDelete = Default + ".BatchDelete";
            public const string ManagePermissions = Default + ".ManagePermissions";
        }
        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(JhAuditLoggingPermissions));
        }
    }
}