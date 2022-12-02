using JustInTime.DAL.Database.Contexts;
using JustInTime.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Jusi.DAL.Repositories
{
    public class Repository<T> : IRepositories<T> where T : class
    {
        private NotesDbContext _context = null;
        private DbSet<T> table = null;
        public Repository()
        {
            this._context = new NotesDbContext();
            table = _context.Set<T>();
        }

        public Repository(NotesDbContext _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetWithInclude(Expression<Func<T, bool>>? predicate, params Expression<Func<T, object>>[] paths)
        {
            IQueryable<T> queryable = this.table.Where(predicate);
            if (paths != null)
            {
                queryable = paths.Aggregate(queryable, (current, path) => current.Include(path));
            }
            return queryable.AsEnumerable();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> queryable = this.table.Where(predicate);
            return queryable.AsEnumerable();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

/*using JustInTime.DAL.Database.Contexts;
using JustInTime.DAL.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JustInTime.DAL.Repositories
{

    public class NoteRepository<T> : IRepository<T> where T : BaseEntity
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
}*/


