using JustInTime.BLL.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace JustInTime.WebApp.Controllers;
public class NoteController : Controller
{
    private readonly INoteService _noteService;

    public NoteController(INoteService noteService)
    {
        _noteService = noteService;
    }


    // GET
    [HttpGet]
    public async Task<IActionResult> GetNotes()
    {
        var response = await _noteService.GetAllNotes();
        return View(response.Data);
    }
    
}