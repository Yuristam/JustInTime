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
    public class CheckListController : Controller
    {
        private readonly NotesDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public CheckListController(NotesDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: TODOS (ALL ToDoS)
        /* public async Task<IActionResult> Index()
         {*/    
        [Authorize]
        public async Task<IActionResult> Index(string searchString)
            {
            string? userId = _httpContextAccessor
               .HttpContext?
               .User?
               .FindFirstValue(ClaimTypes.NameIdentifier);

            var checkLists = from c in _context.CheckLists
                           select c;



            checkLists = _context.CheckLists
                .Include(a => a.Person)
                .Where(p => p.Person.Id == userId);

            if (!String.IsNullOrEmpty(searchString))
            {
                checkLists = checkLists.Where(s => s.Title!.Contains(searchString));
            }



            return View(await checkLists.ToListAsync());
            /*
                        var appDbContext = _context.CheckLists.Include(a => a.Person);
                        return View(await appDbContext.ToListAsync());*/
        }

        // GET: Details   I don't need details here, may be in the future when I will create CheckLists

        // GET: Note/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FirstName");
            return View();                                      // This View is CREATE View 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckListId,PersonId,Title,DateCreated,Todos")] CheckList checkList)
        {
           
            if (!(checkList.PersonId == null))
            {
                _context.Add(checkList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FirstName", checkList.PersonId);

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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FirstName", checkList.PersonId);

            return View(checkList);                                      // this View is EDIT(UPDATE) View
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CheckListId,PersonId,Title,DateCreated,Todos")] CheckList checkList)
        {
            if (id != checkList.CheckListId)
            {
                return NotFound();
            }

            if (id == checkList.CheckListId)
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FirstName", checkList.PersonId);

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
                .Include(a => a.Person)
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
            return _context.CheckLists.Any(e => e.CheckListId == id);
        }
    }
}
