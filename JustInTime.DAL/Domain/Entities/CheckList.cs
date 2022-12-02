namespace JustInTime.DAL.Domain.Entities
{
    public class CheckList
    {
        public int Id { get; set; }
        public virtual List<ToDo> ToDo { get; set; }
    }
}
