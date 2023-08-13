using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AuthNZ.Core.Identity.Pages
{
    [Authorize(Policy = "AdminOnly")]
    public class SettingsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
