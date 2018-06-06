using System.Collections.Generic;

namespace FindFriends.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity:class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();        
        void Update(TEntity obj);
        void Remove(int id);
        void Dispose();
    }
}
