using System.ComponentModel.DataAnnotations;

namespace JustInTime.DAL.Domain.Entities
{

    public abstract class BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}