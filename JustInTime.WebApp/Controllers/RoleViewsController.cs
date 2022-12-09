/*using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustInTime.WebApp.Controllers
{
    public class RoleViewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = Constants.Policies.RequireMember)]
        public IActionResult GroupMember()
        {
            return View();
        }

        [Authorize(Policy = "RequireAdmin")]
        public IActionResult GroupAdmin()
        {
            return View();
        }
    }
}
*/