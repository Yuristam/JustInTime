using JustInTime.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JustInTime.DAL
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions <NotesDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Note> Notes { get; set; }
    }
}
