using JustInTime.DAL.Domain.Entities;

namespace JustInTime.DAL.Repositories
{

    public interface IRepository<T> where T: BaseEntity
    {/*
        Task<bool> Create(T entity);

        Task<Note> Get(int id);

        Task<List<Note>> Select();

        Task<bool> Delete(T entity);
        Task<T> Update(T entity, Note entity1);
    */
        
        
        // I need to do it all in async method (in the future)
        public T Create(T entity);          //CREATE NOTE
        public T Update(T entity);          //EDIT NOTE
        public List<T> ReadAll();           //GET ALL NOTES
        public T ReadById(int id);          //GET BY ID
        public void Delete(T entity);       //DELETE NOTE(i don't know how)
        public void DeleteById(int id);     //DELETE BY ID
    }
}