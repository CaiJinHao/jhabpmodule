namespace Jh.Abp.JhIdentity;

public static class JhIdentityDbProperties
{
    public static string DbTablePrefix { get; set; } = "JhIdentity";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "JhIdentity";
}
