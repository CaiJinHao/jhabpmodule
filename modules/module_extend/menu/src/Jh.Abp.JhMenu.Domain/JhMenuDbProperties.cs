namespace Jh.Abp.JhMenu;

public static class JhMenuDbProperties
{
    public static string DbTablePrefix { get; set; } = "Menu_";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Menu";
}
