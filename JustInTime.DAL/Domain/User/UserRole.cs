using Microsoft.AspNetCore.Identity;


namespace JustInTime.DAL.Domain.User
{
    public class UserRole : IdentityUserRole<long>
    {
        public long UserId { get; set; }

        public long RoleId { get; set; }

        public User User { get; set; }

        public Role Role { get; set; }
    }
}
