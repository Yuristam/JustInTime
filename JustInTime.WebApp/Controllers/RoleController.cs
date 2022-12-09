/*using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace JustInTime.WebApp.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Policy = Constants.Policies.RequireAdmin)]
        public IActionResult GroupMember()
        {
            return View();
        }

        //[Authorize(Policy = "RequireAdmin")]
        [Authorize(Roles = $"{Constants.Roles.GroupAdmin},{Constants.Roles.GroupMember}")]
        public IActionResult GroupAdmin()
        {
            return View();
        }
    }
}
*/