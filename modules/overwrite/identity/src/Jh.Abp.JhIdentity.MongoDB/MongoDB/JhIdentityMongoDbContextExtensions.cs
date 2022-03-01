using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Jh.Abp.JhIdentity.MongoDB;

public static class JhIdentityMongoDbContextExtensions
{
    public static void ConfigureJhIdentity(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
