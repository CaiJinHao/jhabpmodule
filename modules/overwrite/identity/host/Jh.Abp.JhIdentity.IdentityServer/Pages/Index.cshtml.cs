using Microsoft.Extensions.Configuration;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Jh.Abp.JhIdentity.Pages
{
    public class IndexModel : AbpPageModel
    {
        public IConfiguration Configuration { get; init; }
        public IndexModel(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void OnGet()
        {
            Response.Redirect(Configuration["App:AppHomeUrl"]);
        }
    }
}