using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Jh.Abp.Pay.Pages;

public class IndexModel : PayPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
