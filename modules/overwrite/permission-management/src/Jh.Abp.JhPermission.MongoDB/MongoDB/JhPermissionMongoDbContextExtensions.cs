using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Jh.Abp.JhPermission.MongoDB;

public static class JhPermissionMongoDbContextExtensions
{
    public static void ConfigureJhPermission(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
