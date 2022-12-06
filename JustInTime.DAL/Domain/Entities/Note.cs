/*using JustInTime.DAL.Domain.Enums;*/
using System.ComponentModel.DataAnnotations;

namespace JustInTime.DAL.Domain.Entities
{
    public class Note /*: BaseEntity*/
    {
        public Note()
        {
            DateCreated = DateTime.Now;
        }

        public int Id { get; set; }
        [Required]
        [MaxLength(120)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; }  // the day and time when the note was created (it will create date automatically)
        public virtual Type Type { get; set; }

    }

    public enum Type
    {
        [Display(Name = "Urgent")]
        Urgent = 1,
        [Display(Name = "Temporary")]
        Temporary = 2,
        [Display(Name = "Important")]
        Important = 3,
        [Display(Name = "Ordinary")]
        Ordinary = 4,
    }
}
