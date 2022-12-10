using JustInTime.BLL.Controllers;
using JustInTime.DAL.Database.Contexts;
using JustInTime.DAL.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using System.Security.Claims;

namespace JustInTime.WebApp.Controllers
{

    public class NoteController : Controller
    {
        private readonly NotesDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public NoteController(NotesDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: NOTES (ALL NOTES)
        [Authorize]
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            string? userId = _httpContextAccessor
                .HttpContext?
                .User?
                .FindFirstValue(ClaimTypes.NameIdentifier);

           

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var notes = from s in _context.Notes
                        select s;

            notes = _context.Notes
                .Include(a => a.Person)
                .Where(a => a.Person.Id == userId);/*.ToList();*/

            if (!String.IsNullOrEmpty(searchString))
            {
                notes = notes.Where(s => s.Title.Contains(searchString)
                                       || s.Description.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    notes = notes.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    notes = notes.OrderBy(s => s.DateCreated);
                    break;
                case "date_desc":
                    notes = notes.OrderByDescending(s => s.DateCreated);
                    break;
                default:
                    notes = notes.OrderBy(s => s.Title);
                    break;
            }
            return View(await notes.AsNoTracking().ToListAsync());

        }
            // GET: Note/Details/5   (NOTE BY ID)
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notes == null)
            {
                return NotFound();
            }

            var note = await _context.Notes
                .Include(a => a.Person)
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FirstName");
            return View();                                      // This View is CREATE View 
        }

        // POST: Animal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NoteId,PersonId,Title,Description,DateCreated,Type")] Note note)
        {
            if (!(note.PersonId == null ))
            {
                _context.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }/*
            if (ModelState.IsValid)
            {
                _context.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }*/
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FirstName", note.PersonId);

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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FirstName", note.PersonId);

            return View(note);                                      // this View is EDIT(UPDATE) View
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NoteId,PersonId,Title,Description,DateCreated,Type")] Note note)
        {
            if (id != note.NoteId)
            {
                return NotFound();
            }

            /*if (ModelState.IsValid)*/
            if (id == note.NoteId)
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FirstName", note.PersonId);

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
                .Include(a => a.Person)
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