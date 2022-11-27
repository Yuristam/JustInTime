using JustInTime.DAL.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace JustInTime.DAL.Domain.Entities
{
    public class Note : BaseEntity
    {
        public Note()
        {
            DateCreated = DateTime.Now;
        }


        [MaxLength(120)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public ColorHex ColorHex { get; set; } // for the color of notes (in the future in Frontend)
        public DateTime DateCreated { get; set; }  // the day and time when the note was created (it will create date automatically)
        public List<NoteType> NoteType { get; set; } = new List<NoteType>(); // the type of notes (Urgent, temporary and so on)

    }
}
