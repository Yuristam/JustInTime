using Microsoft.AspNetCore.Identity;

namespace JustInTime.DAL.Domain.User
{
    public class Role : IdentityRole<long>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
