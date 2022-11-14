using Microsoft.AspNetCore.Mvc;

namespace JustInTime.WebApp.Controllers;
public class NoteController : Controller
{
    // GET
    [HttpGet]
    public async Task<IActionResult> GetNotes()
    {
        return View();
    }
    
}