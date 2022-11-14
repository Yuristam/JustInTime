using JustInTime.Domain.Entities;

namespace JustInTime.DAL.Interfaces
{

    public interface IBaseRepository<T>
    {
        Task<bool> Create(T entity);

        Task<Note> Get(int id);

        Task<List<Note>> Select();

        Task<bool> Delete(T entity);
    }
}