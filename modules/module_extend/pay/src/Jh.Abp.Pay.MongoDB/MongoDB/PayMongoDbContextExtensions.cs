using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Jh.Abp.Pay.MongoDB;

public static class PayMongoDbContextExtensions
{
    public static void ConfigurePay(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
