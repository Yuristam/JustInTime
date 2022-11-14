using JustInTime.BLL.Entities;
using JustInTime.BLL.Responses;
using JustInTime.BLL.Services.ServiceInterfaces;

namespace JustInTime.BLL.Implementations;

public class NoteService : INoteService
{


    public Task<BaseResponse<IEnumerable<Note>>> GetAllNotes()
    {
        throw new NotImplementedException();
    }
}