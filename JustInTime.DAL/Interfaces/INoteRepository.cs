using JustInTime.BLL.Entities;

namespace JustInTime.DAL.Interfaces;

public interface INoteRepository : IBaseRepository<Note>
{
    Note GetByName(string name);
}