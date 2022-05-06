using Microsoft.Extensions.Configuration;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Wj.CarMsg.Extentions
{
    [Dependency(ReplaceServices = true)]
    public class AppBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName { get; }
        public override string LogoUrl { get; }
        public AppBrandingProvider(IConfiguration configuration)
        {
            AppName = configuration["App:AppName"];
            LogoUrl = configuration["App:LogoUrl"];
        }
    }
}
