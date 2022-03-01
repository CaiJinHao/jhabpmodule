using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Jh.Abp.JhMenu.Pages;

public class IndexModel : JhMenuPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
