using JustInTime.BLL.ServiceInterfaces;
using JustInTime.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustInTime.WebApp.Controllers;
public class NoteController : Controller
{
    private readonly INoteService _noteService;

    public NoteController(INoteService noteService)
    {
        _noteService = noteService;
    }


    // GET ALL THE NOTES
    [HttpGet]
    public async Task<IActionResult> GetNotes()
    {
        var response = await _noteService.GetNotes();
        if (response.StatusCode == Domain.Enums.StatusCode.OK)
        {
            return View(response.Data);
        }
        
        return RedirectToAction("Error");
    }

    // GET NOTE BY ID
    [HttpGet]
    public async Task<IActionResult> GetNote(int id)
    {
        var response = await _noteService.GetNote(id);
        if (response.StatusCode == Domain.Enums.StatusCode.OK)
        {
            return View(response.Data);
        }

        return RedirectToAction("Error");
    }
    
    // DELETE NOTE (вот здесь важный момент, в данном примере удаление доступно только админу, ТАК ЧТО В БУДУЩЕМ ЭТО НАДО ИСПРАВИТЬ)
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _noteService.DeleteNote(id);
        if (response.StatusCode == Domain.Enums.StatusCode.OK)
        {
            return RedirectToAction("GetNotes");
        }

        return RedirectToAction("Error");
    }
    
    // some stupid method do it right 
    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> Save(int id)
    {
        if (id == 0)
        {
            return View();
        }

        var response = await _noteService.GetNote(id);
        if (response.StatusCode == Domain.Enums.StatusCode.OK)
        {
            return View(response.Data);
        }

        return RedirectToAction("Error");
    }
    
    // WTF
    [HttpPost]
    public async Task<IActionResult> Save(Note note)
    {
        if (ModelState.IsValid)
        {
            if (note.Id == 0)
            {
                await _noteService.CreateNote(note);
            }
            else
            {
                await _noteService.EditNote(note.Id, note);
            }
        }

        return RedirectToAction("GetNotes");
    }
    
}