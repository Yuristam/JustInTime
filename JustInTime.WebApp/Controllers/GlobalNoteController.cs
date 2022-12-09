using JustInTime.BLL.Controllers;
using JustInTime.DAL.Database.Contexts;
using JustInTime.DAL.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JustInTime.WebApp.Controllers
{
    public class GlobalNoteController : Controller
    {
        private readonly NotesDbContext _context;

        public GlobalNoteController(NotesDbContext context)
        {
            _context = context;
        }

        // GET: NOTES (ALL NOTES)
        public async Task<IActionResult> Index(
    string sortOrder,
    string currentFilter,
    string searchString,
    int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var notes = from n in _context.Notes
                        select n;
            
            if (!String.IsNullOrEmpty(searchString))
            {
                notes = notes.Where(n => n.Title.Contains(searchString)
                                       || n.Description.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    notes = notes.OrderByDescending(n => n.Title);
                    break;
                case "Date":
                    notes = notes.OrderBy(n => n.DateCreated);
                    break;
                case "date_desc":
                    notes = notes.OrderByDescending(n => n.DateCreated);
                    break;
                default:
                    notes = notes.OrderBy(n => n.Title);
                    break;
            }
            int pageSize = 8;
            return View(await PaginatedList<Note>.CreateAsync(notes.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        // GET: Note/Details/5   (NOTE BY ID)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notes == null)
            {
                return NotFound();
            }

            var note = await _context.Notes
                .FirstOrDefaultAsync(x => x.NoteId == id);
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
        public async Task<IActionResult> Create([Bind("Id,Title,Description,DateCreated")] Note note)
        {
            if (ModelState.IsValid)
            {
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,DateCreated")] Note note)
        {
            if (id != note.NoteId)
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
                    if (!NoteExists(note.NoteId))
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
                .FirstOrDefaultAsync(x => x.NoteId == id);
            if (note == null)
            {
                return NotFound();
            }

            return View(note);                                     // this view is for DELETE
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notes == null)
            {
                return Problem("Entity set 'NotesDbContext.Notes'  is null.");
            }

            var note = await _context.Notes.FindAsync(id);
            if (note != null)
            {
                _context.Notes.Remove(note);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NoteExists(int id)
        {
            return _context.Notes.Any(e => e.NoteId == id);
        }
    }
}
