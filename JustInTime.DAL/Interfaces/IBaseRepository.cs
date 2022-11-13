using JustInTime.BLL.Entities;

namespace JustInTime.DAL.Interfaces;

public interface IBaseRepository<T>
{
    bool Create(T entity);

    Task<Note> Get(int id);

    Task<List<Note>> Select();

    bool Delete(T entity);
}