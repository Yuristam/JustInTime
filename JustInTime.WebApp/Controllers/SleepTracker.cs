using Microsoft.AspNetCore.Mvc;

namespace JustInTime.WebApp.Controllers
{
    public class SleepTracker : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
