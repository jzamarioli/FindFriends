using System.Collections.Generic;

namespace FindFriends.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();        
        void Update(TEntity obj);
        void Remove(int id);
        void Dispose();
    }
}
