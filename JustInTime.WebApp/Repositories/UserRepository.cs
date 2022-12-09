/*using JustInTime.WebApp.Areas.Identity.Data;
using JustInTime.WebApp.IRepositories;

namespace JustInTime.WebApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityContext _context;

        public UserRepository(IdentityContext context)
        {
            _context = context;
        }

        public ICollection<JustInTimeUser> GetUsers()
        {
            return _context.Users.ToList();
        }

        public JustInTimeUser GetUser(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public JustInTimeUser UpdateUser(JustInTimeUser user)
        {
            _context.Update(user);
            _context.SaveChanges();

            return user;
        }
    }
}
*/