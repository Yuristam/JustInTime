using JustInTime.DAL.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace JustInTime.DAL.Domain.Entities
{
    public class Note : BaseEntity
    {
        /* public Note(string title, string description, int colorHex, DateTime dateCreated, int notesType)
         {
             title = Title;
             description = Description;
             colorHex = (int)ColorHex;
             dateCreated = DateTime.Now;
             notesType = (int)NotesType;
         }*/

        public Note()
        {
            DateCreated = DateTime.Now;
        }


        /*public int Id { get; set; }*/
        [MaxLength(120)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public ColorHex ColorHex { get; set; } // for the color of notes (in the future in Frontend)
        public DateTime DateCreated { get; set; }  // the day and time when the note was created (it will create date automatically)
        public NoteTypes NoteType { get; set; }  // the type of notes (Urgent, temporary and so on)
    }
}
