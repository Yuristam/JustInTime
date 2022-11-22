using Microsoft.AspNetCore.Identity;


namespace JustInTime.DAL.Domain.User
{
    public class User : IdentityUser<long>
    {
        public ICollection<UserRole> UserRoles { get; set; }

        public bool IsDeleted { get; set; } = false;
    }

}
