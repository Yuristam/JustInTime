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
    public async Task<bool> Create(Note entity)
    {
        await _db.Notes.AddAsync(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Note> Get(int id)
    {
        return await _db.Notes.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Note>> Select()
    {
        return await _db.Notes.ToListAsync();
    }

    public async Task<bool> Delete(Note entity)
    {
        _db.Notes.Remove(entity);
        await _db.SaveChangesAsync();

        return true;
    }

    public async Task<Note> GetByName(string name)
    {
        return await _db.Notes.FirstOrDefaultAsync(x => x.Name == name);
    }
}