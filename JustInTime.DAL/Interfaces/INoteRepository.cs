using JustInTime.Domain.Entities;

namespace JustInTime.DAL.Interfaces
{

    public interface INoteRepository : IBaseRepository<Note>
    {
        Task<Note> GetByName(string name);
        Task Update(Note entity);
    }
}