namespace JustInTime.DAL.Domain.Entities
{
    public class ToDo : BaseEntity
    {
     /*   public int ToDoId { get; set; }*/
        public string TaskDescription { get; set; }
        public bool IsDone { get; set; }
       // public virtual ApplicationUser User{get;set;}
    }
}
