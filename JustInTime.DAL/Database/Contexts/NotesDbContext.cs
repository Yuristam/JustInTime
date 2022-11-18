using JustInTime.DAL.Domain.Entities;
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
     /*   public DbSet<CheckList> CheckLists { get; set; } // this is the List of notes*/

        // i need to write onModelCreaeting here with has key or has no key (and then add migration)

    }
}
