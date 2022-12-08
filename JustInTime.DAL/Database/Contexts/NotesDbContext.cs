using JustInTime.DAL.Domain.Entities;
using JustInTime.DAL.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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

        public virtual DbSet<Note> Notes { get; set; } 
        public DbSet<CheckList> CheckLists { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<ShortenUser> Users { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>()
                .HasOne(t => t.CheckList)
                .WithMany(c => c.ToDos)
                .HasForeignKey(t => t.CheckListId)
                .IsRequired(false);
        }

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
