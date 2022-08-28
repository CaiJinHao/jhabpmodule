using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.SettingManagement;
using Volo.Abp.Threading;

namespace Jh.Abp.JhIdentity.EntityFrameworkCore;

public static class JhIdentityDbContextModelCreatingExtensions
{
    //private static readonly OneTimeRunner OneTimeRunner = new();

    /// <summary>
    /// 扩展实体 放到PreConfigureServices
    /// </summary>
    public static void ConfigureExtensionDomain()
    {
        JhIdentityModuleExtensionConfigurator.Configure();

        //OneTimeRunner.Run(() =>
        //{

        //});
    }
}
