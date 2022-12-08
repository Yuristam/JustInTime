/*using JustInTime.WebApp.Areas.Identity.Data;
using JustInTime.WebApp.IRepositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JustInTime.WebApp.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityDbContext _context;

        public UserRepository(IdentityDbContext context)
        {
            _context = context;
        }

      *//*  public JustInTimeUser GetUser(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public ICollection<JustInTimeUser> GetUsers()
        {
            throw new NotImplementedException();
        }*/

        /*  public ICollection<JustInTimeUser> GetUsers()
          {
              return _context.Users.ToList();
          }

          public JustInTimeUser GetUser(string id)
          {
              return _context.Users.FirstOrDefault(u => u.Id == id);
          }*/

       /* public JustInTimeUser UpdateUser(JustInTimeUser user)
        {
            _context.Update(user);
            _context.SaveChanges();

            return user;
        }*//*
    }
}
*/