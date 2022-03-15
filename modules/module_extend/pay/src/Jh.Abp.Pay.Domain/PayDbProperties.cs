namespace Jh.Abp.Pay;

public static class PayDbProperties
{
    public static string DbTablePrefix { get; set; } = "Pay";

    public static string DbSchema { get; set; } = null;

    public const string ConnectionStringName = "Pay";
}
