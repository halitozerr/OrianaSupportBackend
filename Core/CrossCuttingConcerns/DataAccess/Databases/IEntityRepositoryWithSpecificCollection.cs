using Core.Entities;
using Core.Entities.Concrete;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess.Databases
{
    public interface IEntityRepositoryWithSpecificCollection<T> where T : class, IEntity, new()
    {
        void UpdateMany(List<MongoDBUpdate> mongoDBUpdates, List<MongoDBFilter> mongoDBFilters);

        void UpdateWithAggregation(PipelineDefinition<T, T> pipeline);
        List<T> GetAll(int page, int limit, Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        ReplaceOneResult Update(T entity);
        void CreateConnectionWithCollectionName(string collectionName);
        List<T> GenerateAggregate(PipelineDefinition<T, T> pipeline);
        void ChangeDataBase(string dataBase);

    }
}
