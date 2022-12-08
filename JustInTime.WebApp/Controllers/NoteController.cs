using JustInTime.DAL.Database.Contexts;
using JustInTime.DAL.Domain.Entities;
using JustInTime.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [Authorize]

        /*  public async Task<IActionResult> Index(string noteType, string searchString)
          {
              // Use LINQ to get list of genres.
              IQueryable<NoteTypes> typeQuery = from n in _context.Notes
                                              orderby n.NoteType
                                              select n.NoteType;
              var notes = from n in _context.Notes
                           select n;

              if (!string.IsNullOrEmpty(searchString))
              {
                  notes = notes.Where(s => s.Title!.Contains(searchString));
              }

              if (!string.IsNullOrEmpty(noteType))
              {
                  notes = notes.Where(x => x.Type == noteType);
              }

              var noteTypeVM = new NoteTypeViewModel
              {
                  Types = new SelectList(await typeQuery.Distinct().ToListAsync()),
                  Notes = await notes.ToListAsync()
              };

              return View(noteTypeVM);
          }*/




        public async Task<IActionResult> Index(string noteType, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<DAL.Domain.Entities.Type> genreQuery = from n in _context.Notes
                                            orderby n.Type
                                            select n.Type;
            var notes = from n in _context.Notes
                         select n;

            if (!string.IsNullOrEmpty(searchString))
            {
                notes = notes.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(noteType))
            {
                notes = notes.Where(x => x.Type.ToString("Temporary") == noteType);
            }

            var noteTypeVM = new NoteTypeViewModel
            {
                Types = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Notes = await notes.ToListAsync()
            };

            return View(noteTypeVM);
        }




        // this is the beginning of the search method

        /*public async Task<IActionResult> Index(string searchString)
        {


            // The beginning of search поиск Note in Notes
            var notes = from n in _context.Notes
                        select n;

            if (!string.IsNullOrEmpty(searchString))
            {
                notes = notes.Where(s => s.Title!.Contains(searchString));
            }
            // the end of the search


            // это Index(in Views/Notes folder). Внутри него идет кнопка поиска( и собсвенно сама функция поиска)
            return View(await notes.ToListAsync());
        }*/

        //this is the end of search method









        // return View(await _context.Notes.ToListAsync());     // INDEX (in Views\Note). This View is showing table of notes(i guess)


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
        public async Task<IActionResult> Create([Bind("Title,Description,DateCreated,Type,Id")] Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Add(note);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


/*

            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "Urgent"});

            items.Add(new SelectListItem { Text = "Ordinary" });

            items.Add(new SelectListItem { Text = "Temporary"});

            items.Add(new SelectListItem { Text = "Important" });

            ViewBag.NoteType = items;*/
            /*

                        var noteTypesData = DAL.Domain.Enums.Type.GetAll();

                        var model = new NoteTypeViewModel();
                        model.NotesTypeSelectList = new List<SelectListItem>();

                        foreach (var noteType in noteTypesData)
                        {
                            model.NotesTypeSelectList.Add(new SelectListItem { Text = noteType.Type });
                        }
            */


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
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,DateCreated,Type,Id")] Note note)
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
            return _context.Notes.Any(e => e.Id == id);
        }

        // АЛГОРИТМ ПОИСКА Search method (found it in Microsoft Learn website)

        /*public async Task<IActionResult> Index(string searchString)
        {
            // поиск Note in Notes
            var notes = from n in _context.Notes
                         select n;

            if (!String.IsNullOrEmpty(searchString))
            {
                notes = notes.Where(s => s.Title!.Contains(searchString));
            }

            // это Index(in Views/Notes folder). Внутри него идет кнопка поиска( и собсвенно сама функция поиска)
            return View(await notes.ToListAsync());
        }*/

        // АЛГОРИТМ ПОИСКА ПО ТИПУ ЗАМЕТКИ (ЖАНРУ) Search by type(genre) (found it in Microsoft Learn website)
        /*public async Task<IActionResult> Index(string noteType, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<NoteTypes> typeQuery = from n in _context.Notes
                                            orderby n.NoteTypes
                                            select n.NoteTypes;
            var notes = from n in _context.Notes
                         select n;

            if (!string.IsNullOrEmpty(searchString))
            {
                notes = notes.Where(s => s.Title!.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(noteType))
            {
                notes = notes.Where(x => x.Type == noteType);
            }

            var noteTypeVM = new NoteTypeViewModel
            {
                Types = new SelectList(await typeQuery.Distinct().ToListAsync()),
                Notes = await notes.ToListAsync()
            };

            return View(noteTypeVM);
        }*/
    }
}