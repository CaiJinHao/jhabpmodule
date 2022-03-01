using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Jh.Abp.JhMenu.MongoDB;

public static class JhMenuMongoDbContextExtensions
{
    public static void ConfigureJhMenu(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
