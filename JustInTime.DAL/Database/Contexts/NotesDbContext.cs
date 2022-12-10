using JustInTime.DAL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
        public virtual DbSet<GlobalNote> GlobalNotes { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Note> Notes { get; set; } 
        public virtual DbSet<CheckList> CheckLists { get; set; }
        public virtual DbSet<ToDo> ToDos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = config.GetConnectionString("NotesConnectionString");

            optionsBuilder
                .UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //many-t0-one
            modelBuilder.Entity<ToDo>()
                .HasOne(t => t.CheckList)
                .WithMany(c => c.ToDos)
                .HasForeignKey(t => t.CheckListId)
                .IsRequired(false);

            modelBuilder.Entity<Person>()
               .HasMany(x => x.Notes)
               .WithOne(x => x.Person)
               .HasForeignKey(x => x.PersonId)
               .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Person>()
              .HasMany(x => x.CheckLists)
              .WithOne(x => x.Person)
              .HasForeignKey(x => x.PersonId)
              .IsRequired();
/*
            modelBuilder.Entity<Note>()
              .HasOne(x => x.Person)
              .WithMany(x => x.Notes)
              .HasForeignKey(x => x.NoteId);*/
            
        }
    }
}
