using JustInTime.DAL.Database.Contexts;
using JustInTime.DAL.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JustInTime.DAL.Repositories
{

    public class NoteRepository<T> : IRepository<T> where T: BaseEntity
    {
        private readonly NotesDbContext _ctx;

        public NoteRepository(NotesDbContext ctx)
        {
            _ctx = ctx;
        }
        
        
        // I need to do it all in async method (in the future)
        
        // CREATE NOTE METHOD
        public T Create(T entity)
        {
            var a = _ctx.Set<T>().Add(entity);
            _ctx.SaveChanges();

            return a.Entity;
        }
        
        // GET ALL THE NOTES METHOD
        public List<T> ReadAll()
        {
            var list = _ctx.Set<T>().ToList();

            return list;
        }
        
        //GET BY ID METHOD
        public T ReadById(int id)
        {
            var entity = _ctx.Set<T>().FirstOrDefault(en => en.Id == id);
            return entity;
        }
        
        //EDIT NOTE METHOD
        public T Update(T entity)
        {
            var a = _ctx.Set<T>().Update(entity);
            _ctx.SaveChanges();

            return a.Entity;
        }
        
        // DELETE NOTE METHOD
        public void Delete(T entity)
        {
            _ctx.Set<T>().Remove(entity);

            _ctx.SaveChanges();
        }
        // DELETE BY ID METHOD
        public void DeleteById(int id)
        {
            var entity = ReadById(id);
            _ctx.Set<T>().Remove(entity);

            _ctx.SaveChanges();
        }
        
        
        /*//CREATE NOTE METHOD
        public async Task<bool> Create(T entity)
        {
            /*var a = #1#await _ctx.Set<T>().AddAsync(entity);
            /*await _ctx.Notes.AddAsync(entity);#1#
            await _ctx.SaveChangesAsync();

            return true;
        }

        //GET BY ID METHOD
        public async Task<Note> GetById(int id)
        {
            return await _ctx.Notes.FirstOrDefaultAsync(x => x.Id == id);
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
        }*/
    }
}