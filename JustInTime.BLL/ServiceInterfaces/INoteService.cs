using JustInTime.Domain.Entities;
using JustInTime.Domain.Responses;

namespace JustInTime.BLL.ServiceInterfaces;

public interface INoteService
{
    Task<IBaseResponse<IEnumerable<Note>>> GetAllNotes();
}