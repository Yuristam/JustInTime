using JustInTime.DAL.Database.Contexts;
using JustInTime.DAL.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JustInTime.WebApp.Controllers
{
    public class CheckListController : Controller
    {
            private readonly NotesDbContext _context;

            public CheckListController(NotesDbContext context)
            {
                _context = context;
            }

            // GET: NOTES (ALL NOTES)
            public async Task<IActionResult> Index()
            {
                return View(await _context.CheckLists.ToListAsync());     // INDEX (in Views\Note). This View is showing table of notes(i guess)
            }

            // GET: Note/Details/5   (NOTE BY ID)
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null || _context.CheckLists == null)
                {
                    return NotFound();
                }

                var checkList = await _context.CheckLists
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (checkList == null)
                {
                    return NotFound();
                }

                return View(checkList);                                  // Just like INDEX View, but for Details (shows table of notes)
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
            public async Task<IActionResult> Create([Bind("ListTitle,ListPointId,ListPoint,IsChecked,Id")] CheckList checkList)
            {
                if (ModelState.IsValid)
                {
                    /* note = new Note() { DateCreated = DateTime.Now };*/   //i need this to be async and to work
                    _context.Add(checkList);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                return View(checkList);                                    // This View is CREATE View 
            }

            // GET: Animal/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null || _context.CheckLists == null)
                {
                    return NotFound();
                }

                var checkList = await _context.CheckLists.FindAsync(id);
                if (checkList == null)
                {
                    return NotFound();
                }

                return View(checkList);                                      // this View is EDIT(UPDATE) View
            }

            // POST: Animal/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, [Bind("ListTitle,ListPointId,ListPoint,IsChecked,Id")] CheckList checkList)
            {
                if (id != checkList.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(checkList);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!CheckListExists(checkList.Id))
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

                return View(checkList);                                              // Edit (update)
            }

            // GET: Animal/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null || _context.CheckLists == null)
                {
                    return NotFound();
                }

                var checkList = await _context.CheckLists
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (checkList == null)
                {
                    return NotFound();
                }

                return View(checkList);                                     // this view is for DELETE
            }

            // POST: Animal/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(int id)
            {
                if (_context.CheckLists == null)
                {
                    return Problem("Entity set 'NotesDbContext.CheckLists'  is null.");
                }

                var checkList = await _context.CheckLists.FindAsync(id);
                if (checkList != null)
                {
                    _context.CheckLists.Remove(checkList);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool CheckListExists(int id)
            {
                return _context.CheckLists.Any(e => e.Id == id);
            }

        }
    }
