using Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess.Databases
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        DeleteResult Delete(T entity);
        ReplaceOneResult Update(T entity);
        DeleteResult DeleteMany(Expression<Func<T, bool>> filter = null);
    }
}
