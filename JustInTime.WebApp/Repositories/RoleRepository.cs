/*using JustInTime.WebApp.Areas.Identity.Data;
using JustInTime.WebApp.IRepositories;
using Microsoft.AspNetCore.Identity;

namespace JustInTime.WebApp.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IdentityContext _context;

        public RoleRepository(IdentityContext context)
        {
            _context = context;
        }

        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
*/