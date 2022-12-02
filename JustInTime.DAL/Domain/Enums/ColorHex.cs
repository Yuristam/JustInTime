using JustInTime.DAL.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace JustInTime.DAL.Domain.Enums
{
    public class ColorHex
    {
        public int Id { get; set; }
        public Color Colors { get; set; }
        public virtual List<Note> Notes { get; set; } /*= new List<Note>();*/

    }
    public enum Color
    {
        [Display(Name = "Red")] Red,
        [Display(Name = "Cyan")] Cyan,
        [Display(Name = "Green")] Green,
        [Display(Name = "Blue")] Blue,
        [Display(Name = "Yellow")] Yellow,
        [Display(Name = "White")] White,
        [Display(Name = "Grey")] Grey,
        [Display(Name = "Magenta")] Magenta,
        [Display(Name = "Orange")] Orange,
        [Display(Name = "Dark Green")] DarkGreen,
    }
}
