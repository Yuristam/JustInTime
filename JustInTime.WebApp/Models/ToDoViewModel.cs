using JustInTime.DAL.Domain.Entities;

namespace JustInTime.WebApp.Models
{
    public class ToDoViewModel
    {

        public ToDoViewModel()
        {
            {
                this.EditableItem = new ToDo();/*
                this.ToDos = db.Query<ToDo>("SELECT * FROM TodoListItems ORDER BY AddDate DESC").ToList();*/
            }
        }
        public List<ToDo> ToDos { get; set; }
        public ToDo EditableItem { get; set; }
    }
}
