using JustInTime.BLL.Entities;
using JustInTime.BLL.Responses;

namespace JustInTime.BLL.Services.ServiceInterfaces;

public interface INoteService
{
    Task<BaseResponse<IEnumerable<Note>>> GetAllNotes();
}