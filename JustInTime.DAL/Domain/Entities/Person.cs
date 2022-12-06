using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace JustInTime.DAL.Domain.Entities
{
    public class Person: IdentityUser
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
       /* public string Email { get; set; }*/
       /* public byte Photo {get; set;}*/
        public int Age { get; set; }
        // public virtual List<Achievement> Achievements { get; set; }
        public bool IsAdmin { get; set; } = false;

    }
}
