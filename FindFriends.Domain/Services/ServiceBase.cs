using System;
using System.Collections.Generic;
using FindFriends.Domain.Interfaces.Repositories;
using FindFriends.Domain.Interfaces.Services;

namespace FindFriends.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }
        public void Add(TEntity obj)
        {
            _repository.Add(obj);
        }
        
        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _repository.GetById(id);
        }
        
        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }

    }
}
