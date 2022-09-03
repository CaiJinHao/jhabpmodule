using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Jh.Abp.IdentityServer
{
    public class RegisterGlobalStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.Add("/libs/register/register.min.css");
        }
    }
}
