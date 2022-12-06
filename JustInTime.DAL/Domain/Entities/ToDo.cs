using System.ComponentModel.DataAnnotations;

namespace JustInTime.DAL.Domain.Entities
{
    public class ToDo
    {
        public int ToDoId { get; set; }
        [Required]
        [MaxLength (120)]
        public string TaskDescription { get; set; }
        public bool IsDone { get; set; } /*=false;*/
        public int CheckListId { get; set; }
        public CheckList CheckList { get; set; }
    }
}
