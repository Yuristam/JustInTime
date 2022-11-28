using JustInTime.DAL.Domain.Entities;
using JustInTime.DAL.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace JustInTime.DAL.Database.Contexts
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions <NotesDbContext> options): base(options)
        {

        }

        public NotesDbContext()
        {
            
        }
        
        public DbSet<Note> Notes { get; set; } // this is just ordinary note
        public DbSet<ToDo> ToDos { get; set; } // this is ToDo notes
        /*   public DbSet<CheckList> CheckLists { get; set; } // this is the List of notes*/


    }
}
