using JustInTime.DAL.Domain.Entities;

namespace JustInTime.DAL.Domain.Enums
{
    public class NoteType : BaseEntity
    {
        public string Type { get; set; }
        public List<Note> Notes { get; set; } = new List<Note>();
    }/*
    public static class Type
    {
        public static List<NoteType> GetAll()
        {
            return new List<NoteType>()
            {
                new NoteType { Type = "Ordinary"},
                new NoteType { Type ="Important"},
                new NoteType { Type = "Urgent"},
                new NoteType { Type = "Temporary"},
            };
        }
    }*/
}
