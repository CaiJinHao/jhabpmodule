using Volo.Abp.Data;

namespace Jh.Abp.JhIdentity;

public static class JhIdentityDbProperties
{
    public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

    public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

    public const string ConnectionStringName = "AbpIdentity";
}
