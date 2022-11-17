/*using JustInTime.DAL.Contexts;
using JustInTime.DAL.Interfaces;
using JustInTime.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace JustInTime.DAL.Repositories
{

    public class NoteRepository : INoteRepository
    {
        private readonly NotesDbContext _db;

        public NoteRepository(NotesDbContext db)
        {
            _db = db;
        }
        
        //CREATE NOTE METHOD
        public async Task<bool> Create(Note entity)
        {
            await _db.Notes.AddAsync(entity);
            await _db.SaveChangesAsync();

            return true;
        }

        //GET BY ID METHOD
        public async Task<Note> Get(int id)
        {
            return await _db.Notes.FirstOrDefaultAsync(x => x.Id == id);
        }

        // GET ALL NOTES METHOD (SELECT)
        public async Task<List<Note>> Select()
        {
            return await _db.Notes.ToListAsync();
        }

        // DELETE METHOD
        public async Task<bool> Delete(Note entity)
        {
            _db.Notes.Remove(entity);
            await _db.SaveChangesAsync();

            return true;
        }
        
        //Update (edit) METHOD
        public async Task<Note> Update(Note entity)
        {
            _db.Notes.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }

        // GET BY NAME METHOD
        public async Task<Note> GetByName(string name)
        {
            return await _db.Notes.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}*/