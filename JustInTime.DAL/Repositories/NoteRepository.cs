using JustInTime.BLL.Entities;
using JustInTime.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JustInTime.DAL.Repositories;

public class NoteRepository: INoteRepository
{
    private readonly NotesDbContext _db;

    public NoteRepository(NotesDbContext db)
    {
        _db = db;
    }
    public bool Create(Note entity)
    {
        throw new NotImplementedException();
    }

    public Note Get(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Note>> Select()
    {
        return await _db.Notes.ToListAsync();
    }

    public bool Delete(Note entity)
    {
        throw new NotImplementedException();
    }

    public Note GetByName(string name)
    {
        throw new NotImplementedException();
    }
}