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

        public DbSet<Note> Notes { get; set; }
        
    }
}
