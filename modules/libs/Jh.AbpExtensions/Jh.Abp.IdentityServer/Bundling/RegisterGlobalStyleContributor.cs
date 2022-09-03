using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Jh.Blog
{
    public class RegisterGlobalStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.Add("/themes/register.css");
        }
    }
}
