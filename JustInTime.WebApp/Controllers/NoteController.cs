using JustInTime.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JustInTime.WebApp.Controllers;
public class NoteController : Controller
{
    private readonly INoteRepository _noteRepository;
    
    public NoteController(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }
    // GET
    [HttpGet]
    public async Task<IActionResult> GetNotes()
    {
        var response = await _noteRepository.Select();
        return View(response);
    }
    
}