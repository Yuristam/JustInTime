using JustInTime.Domain.Entities;
using JustInTime.Domain.Responses;

namespace JustInTime.BLL.ServiceInterfaces;

public interface INoteService
{
    Task<IBaseResponse<IEnumerable<Note>>> GetNotes();
    Task<IBaseResponse<Note>> GetNote(int id);
    Task<IBaseResponse<Note>> CreateNote(Note note);
    Task<IBaseResponse<bool>> DeleteNote(int id);
    Task<IBaseResponse<Note>> GetNoteByName(string name);
}