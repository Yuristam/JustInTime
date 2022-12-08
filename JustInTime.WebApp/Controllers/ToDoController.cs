using JustInTime.DAL.Database.Contexts;
using JustInTime.DAL.Domain.Entities;
using JustInTime.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
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

        // GET: TODOS (ALL ToDoS)
        public async Task<IActionResult> Index()
        {

            ToDoViewModel viewModel = new ToDoViewModel();
            return View("Index", viewModel);     // INDEX (in Views\Note). This View is showing table of notes(i guess)
        }

        // GET: Note/Details/5   I don't need details here, may be in the future when I will create CheckLists

        // GET: Note/Create
        public IActionResult Create(int id) // THIS IS MAY BE LIKE THIS (int? id)
        {
            ToDoViewModel viewModel = new ToDoViewModel();
            viewModel.EditableItem = viewModel.ToDos.FirstOrDefault(x => x.ToDoId == id);
            return View("Index", viewModel);                                   // This View is CREATE View 
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ToDos == null)
            {
                return NotFound();
            }

            var toDo = await _context.ToDos
                .FirstOrDefaultAsync(x => x.ToDoId == id);
            if (toDo == null)
            {
                return NotFound();
            }
            if (_context.ToDos == null)
            {
                return Problem("Entity set 'NotesDbContext.Notes'  is null.");
            }

            toDo = await _context.ToDos.FindAsync(id);
            if (toDo != null)
            {
                _context.ToDos.Remove(toDo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CreateUpdate(ToDoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
               /* using (var db = DbHelper.GetConnection())*/
                {
                    if (viewModel.EditableItem.ToDoId <= 0)
                    {
                        viewModel.EditableItem.AddDate = DateTime.Now;
                        _context.Add<ToDo>(viewModel.EditableItem);
                    }
                    else
                    {
                        ToDo dbItem = _context.Find<ToDo>(viewModel.EditableItem.ToDoId);
                        var result = TryUpdateModelAsync<ToDo>(dbItem, "EditableItem");
                        _context.Update<ToDo>(dbItem);
                    }
                }
                return RedirectToAction("Index");
            }
            else
                return View("Index", new ToDoViewModel());
        }
        public IActionResult ToggleIsDone(int id)
        {
            /*using (var db = DbHelper.GetConnection())
            */{
                ToDo item = _context.Find<ToDo>(id);
                if (item != null)
                {
                    item.IsDone = !item.IsDone;
                    _context.Update<ToDo>(item);
                }
                return RedirectToAction("Index");
            }
        }
    }
}
