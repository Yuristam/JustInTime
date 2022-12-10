using System.ComponentModel.DataAnnotations;

namespace JustInTime.DAL.Domain.Entities
{
    public class GlobalNote
    {
        public GlobalNote()
        {
            DateCreated = DateTime.Now;
        }
        public int Id { get; set; }
        
        [Required]
        [MaxLength(120)]
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime DateCreated { get; set; }
        
    }
}
