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
    }
}