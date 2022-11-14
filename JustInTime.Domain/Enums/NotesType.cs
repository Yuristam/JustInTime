using System.ComponentModel.DataAnnotations;

namespace JustInTime.Domain.Enums
{
    public enum NotesType
    {
        [Display (Name = "Urgent")]
        Urgent =0, // Red
        [Display (Name = "Temporary")] // bright blue
        Temporary = 1,
        [Display (Name = "Important")] // Green Bright
        Important = 2,
        [Display (Name = "Ordinary")] // white
        Ordinary = 3,
    }
}
