using JustInTime.DAL.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace JustInTime.DAL.Domain.Enums
{
    public enum NoteTypes
    {
        [Display(Name = "Urgent")]
        Urgent = 0,
        [Display(Name = "Temporary")]
        Temporary = 1,
        [Display(Name = "Important")]
        Important = 2,
        [Display(Name = "Ordinary")]
        Ordinary = 3,
    }
    /*public class NoteType : BaseEntity
    {
        public string Type { get; set; }
        public void SetType(string type)
        {
            switch(type)
            {
                case "Urgent": Type = Urgent;

                    break;

            }
        }

    }*/
}
