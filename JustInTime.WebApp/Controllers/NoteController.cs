using JustInTime.DAL.Database.Contexts;
using JustInTime.DAL.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JustInTime.WebApp.Controllers
{

    public class NoteController : Controller
    {
        private readonly NotesDbContext _context;

        public NoteController(NotesDbContext context)
        {
            _context = context;
        }

        // GET: NOTES (ALL NOTES)
        public async Task<IActionResult> Index()
        {
            return View(await _context.Notes.ToListAsync());     // INDEX (in Views\Note). This View is showing table of notes(i guess)
        }

        // GET: Note/Details/5   (NOTE BY ID)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notes == null)
            {
                return NotFound();
            }

            var note = await _context.Notes
                .FirstOrDefaultAsync(x => x.Id == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);                                  // Just like INDEX View, but for Details (shows table of notes)
        }

        // GET: Note/Create
        public IActionResult Create()
        {
            return View();                                      // This View is CREATE View 
        }

        // POST: Animal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,ColorHex,DateCreated,NotesType")] Note note)
        {
            if (ModelState.IsValid)
            {
               /* note = new Note() { DateCreated = DateTime.Now };*/   //i need this to be async and to work
                _context.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(note);                                    // This View is CREATE View 
        }

        // GET: Animal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Notes == null)
            {
                return NotFound();
            }

            var note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);                                      // this View is EDIT(UPDATE) View
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,ColorHex,DateCreated,NotesType")] Note note)
        {
            if (id != note.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(note);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NoteExists(note.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(note);                                              // Edit (update)
        }

        // GET: Animal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notes == null)
            {
                return NotFound();
            }

            var note = await _context.Notes
                .FirstOrDefaultAsync(x => x.Id == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);                                     // this view is for DELETE
        }

        // POST: Animal/Delete/5
        [HttpDelete, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notes == null)
            {
                return Problem("Entity set 'NotesDbContext.Notes'  is null.");
            }

            var animal = await _context.Notes.FindAsync(id);
            if (animal != null)
            {
                _context.Notes.Remove(animal);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteExists(int id)
        {
            return _context.Notes.Any(e => e.Id == id);
        }





        /*
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
                if (response.StatusCode == DAL.Domain.Enums.StatusCode.OK)
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
                if (response.StatusCode == DAL.Domain.Enums.StatusCode.OK)
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
                if (response.StatusCode == DAL.Domain.Enums.StatusCode.OK)
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
                if (response.StatusCode == DAL.Domain.Enums.StatusCode.OK)
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
            }*/



    }
}