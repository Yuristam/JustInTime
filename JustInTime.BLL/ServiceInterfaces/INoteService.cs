using JustInTime.BLL.Entities;
using JustInTime.BLL.Responses;

namespace JustInTime.BLL.ServiceInterfaces;

public interface INoteService
{
    Task<BaseResponse<IEnumerable<Note>>> GetAllNotes();
}