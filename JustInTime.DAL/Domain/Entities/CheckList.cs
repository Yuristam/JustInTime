using System.ComponentModel.DataAnnotations;

namespace JustInTime.DAL.Domain.Entities
{
    public class CheckList
    {
        public CheckList()
        {
            DateCreated = DateTime.Now;
        }
        public int CheckListId { get; set; }

        public virtual Person Person { get; set; }
        public string PersonId { get; set; }
        [Required]
        [MaxLength (120)]
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual List<ToDo> ToDos { get; set; } = new List<ToDo>();
    }
}
