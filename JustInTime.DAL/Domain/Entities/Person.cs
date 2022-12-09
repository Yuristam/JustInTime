using System.ComponentModel.DataAnnotations;

namespace JustInTime.DAL.Domain.Entities
{
    public class Person
    {
        public string Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthdayDate { get; set; }
        public bool IsAdmin { get; set; } = false;
        public virtual List<Note> Notes { get; set; } = new List<Note>();
        public virtual List<CheckList> CheckLists { get; set; } = new List<CheckList>();


    }
}
