using System.ComponentModel.DataAnnotations;

namespace JustInTime.Domain.Enums;

public enum ColorHex
{
    [Display (Name = "Red")]
    Red =0,
    [Display (Name = "Cyan")] 
    Cyan = 1,
    [Display (Name = "Green")] 
    Green = 2,
    [Display (Name = "Blue")] 
    Blue = 3,
    [Display (Name = "Yellow")] 
    Yellow = 4,
    [Display (Name = "White")]
    White = 5,
    [Display (Name = "Grey")] 
    Grey = 6,
    [Display (Name = "Magenta")] 
    Magenta = 7,
    [Display (Name = "Orange")] 
    Orange = 8,
}