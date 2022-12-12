using JustInTime.DAL.Database.Contexts;
using JustInTime.DAL.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace JustInTime.WebApp.Controllers
{
    public class ToDoController : Controller
    {

        private readonly NotesDbContext _context;

        public ToDoController(NotesDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ToDos
                .Include(f => f.CheckList);
            return View(await appDbContext.ToListAsync());
        }


        public IActionResult Create()
        {
            ViewData["CheckListId"] = new SelectList(_context.CheckLists, "CheckListId", "Title");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ToDoId,CheckListId,TaskDescription,IsDone")] ToDo toDo)
        {
            if (/*toDo.ToDoId == 0*/!(toDo.CheckListId == null))
            {   
                _context.Add(toDo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CheckListId"] = new SelectList(_context.CheckLists, "CheckListId", "Title", toDo.CheckListId);

            return View(toDo);
        }

        // GET: Animal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }

            ViewData["CheckListId"] = new SelectList(_context.CheckLists, "CheckListId", "Title", toDo.CheckListId);
            return View(toDo);
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ToDoId,CheckListId,TaskDescription,IsDone")] ToDo toDo)
        {
            if (id != toDo.ToDoId)
            {
                return NotFound();
            }

            if (id != toDo.ToDoId)
            {
                try
                {
                    _context.Update(toDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoExists(toDo.ToDoId))
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
            ViewData["CheckListId"] = new SelectList(_context.CheckLists, "CheckListId", "Title", toDo.CheckListId);

            return View(toDo);                                              // Edit (update)
        }

        // GET: Todo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos
                  .Include(a => a.CheckList)
                .FirstOrDefaultAsync(x => x.ToDoId == id);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(toDo);                                     // this view is for DELETE
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ToDos == null)
            {
                return Problem("Entity set 'NotesDbContext.Todos'  is null.");
            }

            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo != null)
            {
                _context.ToDos.Remove(toDo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoExists(int id)
        {
            return _context.ToDos.Any(e => e.ToDoId == id);
        }
    }
}
