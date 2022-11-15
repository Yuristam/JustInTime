using JustInTime.Domain.Enums;

namespace JustInTime.Domain.Entities
{
    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ColorHex ColorHex { get; set; } // for the color of notes (in the future in Frontend)
        public DateTime DateCreated { get; set; } // the day and time when the note was created (it will create date automatically)
        public NotesType NotesType { get; set; }  // the type of notes (Urgent, temporary and so on)
    }
}
