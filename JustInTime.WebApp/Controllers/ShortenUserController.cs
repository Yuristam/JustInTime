using JustInTime.DAL.Database.Contexts;
using JustInTime.DAL.Domain.Identity;
using JustInTime.WebApp.Areas;
using JustInTime.WebApp.Areas.Identity.Data;

namespace JustInTime.WebApp.Controllers
{
    public class ShortenUserController : IShortedUserController
    {
        private readonly NotesDbContext _context;
        public ShortenUserController(NotesDbContext context)
        {
            _context = context;
        }
        public void AddUser(JustInTimeUser user)
        {
            var shortenUser = MapUser(user);
            _context.Users.Add(shortenUser);

            _context.SaveChanges();
        }

        private ShortenUser MapUser(JustInTimeUser justInTimeUser)
        {
            return new ShortenUser()
            {
                Id = justInTimeUser.Id,
                Nickname = justInTimeUser.UserName
            };
        }
    }
}