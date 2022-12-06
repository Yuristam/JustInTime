using System.ComponentModel.DataAnnotations;

namespace JustInTime.DAL.Domain.Entities
{
    public class CheckList
    {
        public int CheckListId { get; set; }
        [Required]
        [MaxLength (120)]
        public string Title { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public virtual ICollection<ToDo> ToDos { get; set; }
    }
}
