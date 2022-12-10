
using System.ComponentModel.DataAnnotations;

namespace JustInTime.DAL.Domain.Entities
{
    public class Note /*: BaseEntity*/
    {
        public Note()
        {
            DateCreated = DateTime.Now;
        }

        public int NoteId { get; set; }
        public virtual Person Person { get; set; }
        public string PersonId { get; set; }
        [Required]
        [MaxLength(120)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; }  
        public virtual Type Type { get; set; }
    }

    public enum Type
    {
        [Display(Name = "Urgent")]
        Urgent,
        [Display(Name = "Temporary")]
        Temporary,
        [Display(Name = "Important")]
        Important,
        [Display(Name = "Ordinary")]
        Ordinary,
    }
}
