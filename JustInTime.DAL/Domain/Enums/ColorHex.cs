using JustInTime.DAL.Domain.Entities;

namespace JustInTime.DAL.Domain.Enums
{
    public class ColorHex : BaseEntity
    {
        public string Color { get; set; }
        public List<Note> Notes { get; set; } = new List<Note>();
      /*  public enum ColorsHex
        {
            [Display(Name = "Red")] Red = 0,
            [Display(Name = "Cyan")] Cyan = 1,
            [Display(Name = "Green")] Green = 2,
            [Display(Name = "Blue")] Blue = 3,
            [Display(Name = "Yellow")] Yellow = 4,
            [Display(Name = "White")] White = 5,
            [Display(Name = "Grey")] Grey = 6,
            [Display(Name = "Magenta")] Magenta = 7,
            [Display(Name = "Orange")] Orange = 8,
            [Display(Name = "Dark Green")] DarkGreen = 9,
        }*/
    }
}
