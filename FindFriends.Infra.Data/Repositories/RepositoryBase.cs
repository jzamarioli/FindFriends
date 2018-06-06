using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using FindFriends.Infra.Data.Context;
using FindFriends.Domain.Interfaces.Repositories;

namespace FindFriends.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly FindFriendsContext _ctx;

        public RepositoryBase(FindFriendsContext databaseContext)              
        {
            _ctx = databaseContext;
        }
        
        public void Add(TEntity obj)
        {
            _ctx.Set<TEntity>().Add(obj);
            _ctx.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return _ctx.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _ctx.Set<TEntity>().ToList();
        }
        
        public void Remove(int id)
        {
            TEntity obj = _ctx.Set<TEntity>().Find(id);
            if (obj != null)
            {
                _ctx.Set<TEntity>().Remove(obj);
                _ctx.SaveChanges();
            }
            else
            {
                throw new Exception("Id Não Encontrado");
            }
        }

        public void Update(TEntity obj)
        {
            _ctx.Entry(obj).State = EntityState.Modified;
            _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }

    }
}
