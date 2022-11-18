
using System.ComponentModel.DataAnnotations;

namespace JustInTime.DAL.Domain.Entities
{
    public class CheckList : BaseEntity
    {/*
        public CheckList() { }*/
        /*public int Id { get; set; }*/
        [MaxLength(120)]
        public string ListTitle { get; set; } // the title of list
        public List<int>? ListPointId { get; set; } // this is the number of 
        [MaxLength(200)]
        public List<string>? ListPoint { get; set; } // this is a list of points (it is for check (tik))
        public bool ?IsChecked { get; set; } // is tik (this might be list)

    }
}
