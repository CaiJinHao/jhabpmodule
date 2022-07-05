using Volo.Abp.Reflection;
using Volo.Abp.SettingManagement;

namespace Jh.Abp.SettingManagement.Permissions
{
    public class JhSettingManagementPermissions
    {
        public const string GroupName = SettingManagementPermissions.GroupName;

        public class Settings
        {
            public const string Default = GroupName + ".Settings";
            public const string Update = Default + ".Update";
            public const string ManagePermissions = Default + ".ManagePermissions";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(JhSettingManagementPermissions));
        }
    }
}