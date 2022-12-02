using System.ComponentModel.DataAnnotations;

namespace JustInTime.DAL.Domain.Entities
{
    public class ToDo
    {
        public int Id { get; set; }
        [Required]
        [MaxLength (120)]
        public string TaskDescription { get; set; }
        public bool IsDone { get; set; }
        public virtual List<CheckList> CheckList { get; set; }/* = new List<CheckList>();*/
    }
}
