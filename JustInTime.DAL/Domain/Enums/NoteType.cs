using JustInTime.DAL.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace JustInTime.DAL.Domain.Enums
{
    public class NoteType
    {
        public int Id { get; set; }
        public virtual Type Type { get; set; }
        public List<Note> Notes { get; set; } = new List<Note>();
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
