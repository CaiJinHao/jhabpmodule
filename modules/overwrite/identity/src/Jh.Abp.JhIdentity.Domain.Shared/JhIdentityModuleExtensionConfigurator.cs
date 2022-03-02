using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Threading;

namespace Jh.Abp.JhIdentity
{
    public static class JhIdentityModuleExtensionConfigurator
    {
        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public static void Configure()
        {
            OneTimeRunner.Run(() =>
            {
                ConfigureExistingProperties();
            });
        }

        private static void ConfigureExistingProperties()
        {
            /* You can change max lengths for properties of the
             * entities defined in the modules used by your application.
             *
             * Example: Change user and role name max lengths
             
               IdentityUserConsts.MaxNameLength = 99;
               IdentityRoleConsts.MaxNameLength = 99;
             
             * Notice: It is not suggested to change property lengths
             * unless you really need it. Go with the standard values wherever possible.
             */
            //TODO:修改现有的数据库长度配置
            //超过一定长度会自动改为text
            //AuditLogConsts.MaxCommentsLength = int.MaxValue;
            //AuditLogActionConsts.MaxParametersLength = int.MaxValue;
        }
    }
}
