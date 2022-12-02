using JustInTime.DAL.Domain.Entities;
using JustInTime.DAL.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace JustInTime.DAL.Database.Contexts
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions<NotesDbContext> options) : base(options)
        {

        }

        public NotesDbContext()
        {

        }

        public virtual DbSet<Note> Notes { get; set; } // this is just ordinary note
        public virtual DbSet<NoteType> NoteTypes { get; set; } // this is for many-to-many 
        public virtual DbSet<ColorHex> ColorHexes { get; set; } // this is for many-to-many 
        public virtual DbSet<ToDo> ToDos { get; set; } // this is ToDo notes
        public virtual DbSet<CheckList> CheckLists { get; set; } // this is the List of notes

    /*    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Note>()
                .HasKey(x => x.NoteType)
                .WithMany(x => x.ColorHex)
                .HasForiegnKey(x => x.)

        }*/
    }
}
