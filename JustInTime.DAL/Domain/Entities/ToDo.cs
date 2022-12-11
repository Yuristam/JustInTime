using System.ComponentModel.DataAnnotations;

namespace JustInTime.DAL.Domain.Entities
{
    public class ToDo
    {
        public int ToDoId { get; set; }
        public virtual CheckList CheckList { get; set; }
        public int CheckListId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Task Description must contain at least one characters!")]
        [MaxLength(200, ErrorMessage = "Task Description must contain a maximum of 200 characters!")]
        public string TaskDescription { get; set; }  //this is kinda Title

        public bool IsDone { get; set; }
    }
}
