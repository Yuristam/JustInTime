using JustInTime.BLL.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace JustInTime.DAL
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions <NotesDbContext> options): base(options)
        {

        }
        DbSet<Note> Notes { get; set; }
    }
}
