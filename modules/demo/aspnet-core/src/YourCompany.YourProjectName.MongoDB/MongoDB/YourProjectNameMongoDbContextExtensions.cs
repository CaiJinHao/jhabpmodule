using Volo.Abp;
using Volo.Abp.MongoDB;

namespace YourCompany.YourProjectName.MongoDB;

public static class YourProjectNameMongoDbContextExtensions
{
    public static void ConfigureYourProjectName(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
