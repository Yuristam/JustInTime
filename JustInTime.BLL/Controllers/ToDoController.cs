/*using JustInTime.DAL.Database.Contexts;
using JustInTime.DAL.Domain.Entities;
using JustInTime.DAL.Repositories;

namespace JustInTime.BLL.Controllers
{
    public class ToDoController
    {
        private IRepository<ToDo> _toDoRepository;
        public ToDoController(IRepository<ToDo> repository)
        {
            NotesDbContext context = new NotesDbContext();
            _toDoRepository = new NoteRepository<ToDo>(context);
        }
        public ToDo Create(ToDo toDo)
        {
            return _toDoRepository.Create(toDo);
        }
    }
}
*/