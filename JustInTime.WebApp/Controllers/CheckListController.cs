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

        // GET: TODOS (ALL ToDoS)
        public async Task<IActionResult> Index()
        {
            return View(await _context.CheckLists.ToListAsync());
        }

        // GET: Details   I don't need details here, may be in the future when I will create CheckLists

        // GET: Note/Create
        public IActionResult Create()
        {
            return View();                                      // This View is CREATE View 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckListId,Title,DateCreated,ToDos")] CheckList checkList)
        {
            if (ModelState.IsValid)
            {
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
        public async Task<IActionResult> Edit(int id, [Bind("CheckListId,Title,DateCreated,ToDos")] CheckList checkList)
        {
            if (id != checkList.CheckListId)
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
                    if (!CheckListExists(checkList.CheckListId))
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

        // GET: Todo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CheckLists == null)
            {
                return NotFound();
            }

            var checkList = await _context.CheckLists
                .FirstOrDefaultAsync(x => x.CheckListId == id);
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
                return Problem("Entity set 'NotesDbContext.Notes'  is null.");
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
            return _context.CheckLists.Any(e => e.CheckListId == id);
        }
    }
}
