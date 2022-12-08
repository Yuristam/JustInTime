using System.ComponentModel.DataAnnotations;

namespace JustInTime.DAL.Domain.Entities
{
    public class ToDo
    {
        public int ToDoId { get; set; }
        /* public int Id { get; set; } *//*
        [Required]
        [MaxLength (120)]
        public string TaskDescription { get; set; }
        public bool IsDone { get; set; } *//*=false;*/

        public DateTime AddDate { get; set; } // this might be deleted for me (но это нужно для сортировки по дате)

        [Required]
        [MinLength(1, ErrorMessage = "Task Description must contain at least one characters!")]
        [MaxLength(200, ErrorMessage = "Task Description must contain a maximum of 200 characters!")]
        public string TaskDescription { get; set; }  //this is kinda Title

        public bool IsDone { get; set; }
        public int CheckListId { get; set; }
        public CheckList CheckList { get; set; }
    }
}
