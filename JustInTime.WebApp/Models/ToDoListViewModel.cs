/*using JustInTime.DAL.Database.Contexts;
using JustInTime.DAL.Domain.Entities;

namespace JustInTime.WebApp.Models
{
    public class TodoListViewModel
    {
        public TodoListViewModel()
        {
            using (var db = NotesDbContext.GetConnection()
            {
                this.EditableItem = new ToDo();
                this.TodoItems = db.Query<ToDo>("SELECT * FROM TodoListItems ORDER BY AddDate DESC").ToListAsync();
            }
        }

        public List<ToDo> TodoItems { get; set; }

        public ToDo EditableItem { get; set; }
    }
}
*/