﻿using Microsoft.EntityFrameworkCore;
using System;
using Volo.Abp;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Threading;

namespace Jh.Abp.JhIdentity.EntityFrameworkCore;

public static class JhIdentityDbContextModelCreatingExtensions
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void ConfigureJhIdentity(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));


    }

    /// <summary>
    /// 扩展实体  放到PreConfigureServices
    /// </summary>
    public static void ConfigureExtensionDomain()
    {
        JhIdentityModuleExtensionConfigurator.Configure();

        OneTimeRunner.Run(() =>
        {
            ObjectExtensionManager.Instance.MapEfCoreProperty<OrganizationUnit, Guid?>(nameof(ObjectExtensionConst.OrganizationUnit.LeaderId), (e, p) =>
            {
                p.HasComment("领导ID");
            });
            ObjectExtensionManager.Instance.MapEfCoreProperty<OrganizationUnit, string>(nameof(ObjectExtensionConst.OrganizationUnit.LeaderName), (e, p) =>
            {
                p.HasMaxLength(50).HasComment("领导名称");
            });
        });
    }
}
