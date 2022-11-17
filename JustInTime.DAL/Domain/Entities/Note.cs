using JustInTime.DAL.Domain.Enums;

namespace JustInTime.DAL.Domain.Entities
{
    public class Note : BaseEntity
    {/*
        public Note(int id, string title, string description, int colorHex, DateTime dateCreated, int notesType)
        {
            id = Id;
            title = Title;
            description = Description;
            colorHex = (int)ColorHex;
            dateCreated = DateCreated;
            notesType = (int)NotesType;
        }*/

        /*public int Id { get; set; }*/
        public string Title { get; set; }
        public string ?Description { get; set; }
        public ColorHex ColorHex { get; set; } // for the color of notes (in the future in Frontend)
        public DateTime DateCreated { get; set; } // the day and time when the note was created (it will create date automatically)
        public NotesType NotesType { get; set; }  // the type of notes (Urgent, temporary and so on)
    }
}
