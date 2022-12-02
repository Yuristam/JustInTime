/*using JustInTime.DAL.Database.Contexts;
using JustInTime.DAL.Domain.Entities;
using JustInTime.DAL.Repositories;

namespace JustInTime.BLL.Controllers;

public class NoteController
{
    private IRepository<Note> _noteRepository;
    public NoteController(IRepository<Note> repository)
    {
        NotesDbContext context = new NotesDbContext();
        _noteRepository = new NoteRepository<Note>(context);
    }
    public Note Create(Note note)
    {
        return _noteRepository.Create(note);
    }
}*/