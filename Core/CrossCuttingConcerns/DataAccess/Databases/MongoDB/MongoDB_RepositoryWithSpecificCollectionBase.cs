using Core.Entities;
using Core.Entities.Concrete;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess.Databases.MongoDB
{
    public class MongoDB_RepositoryWithSpecificCollectionBase<TEntity, MongoDBUsedDeviceDataContext> : IDisposable, IEntityRepositoryWithSpecificCollection<TEntity>
           where TEntity : class, IEntity, new()
       where MongoDBUsedDeviceDataContext : class, IMongoDB_RawLogContext<TEntity>, new()
    {

        public IMongoCollection<TEntity> _collection { get; set; }
        private IMongoDatabase database;
        private MongoDBUsedDeviceDataContext mongoDBContext = new MongoDBUsedDeviceDataContext();
        public MongoDB_RepositoryWithSpecificCollectionBase()
        {

          
            database = mongoDBContext.GetMongoDBDatabase();
        }
        public void ChangeDataBase(string dataBase)
        {
            database = mongoDBContext.GetMongoDBDatabase(dataBase);
        }
        /*-------------------------------------------------------------------------------------------------------------*/
        public void CreateConnectionWithCollectionName(string collectionName)
        {
            _collection = database.GetCollection<TEntity>(collectionName);
        }

        /*-------------------------------------------------------------------------------------------------------------*/
        public void Add(TEntity entity)
        {
            _collection.InsertOne(entity);
        }

        /*-------------------------------------------------------------------------------------------------------------*/
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {


            return _collection.Find<TEntity>(filter).Sort("{_id:-1}").FirstOrDefault();
        }

        /*-------------------------------------------------------------------------------------------------------------*/

        public List<TEntity> GetAll(int page, int limit, Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                return filter == null
            ? _collection.Find<TEntity>(document => true).Sort("{_id:-1}").Skip((page - 1) * limit).Limit(limit).ToList()
            : _collection.Find<TEntity>(filter).Sort("{_id:-1}").Skip((page - 1) * limit).Limit(limit).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /*-------------------------------------------------------------------------------------------------------------*/

        public ReplaceOneResult Update(TEntity entity)
        {
            return _collection.ReplaceOne(e => e.Id == entity.Id, entity);
        }

        /*-------------------------------------------------------------------------------------------------------------*/
        public void UpdateMany(List<MongoDBUpdate> mongoDBUpdates, List<MongoDBFilter> mongoDBFilters)
        {
            List<UpdateDefinition<TEntity>> updateDefination = new List<UpdateDefinition<TEntity>>();
            List<FilterDefinition<TEntity>> filterDefinitions = new List<FilterDefinition<TEntity>>();

            foreach (var mongoDBUpdate in mongoDBUpdates)
            {
                updateDefination.Add(Builders<TEntity>.Update.Set(mongoDBUpdate.Field, mongoDBUpdate.NewValue));
            }

            foreach (var filter in mongoDBFilters)
            {
                if (filter.Filter.GetType() == typeof(bool))
                {
                    filterDefinitions.Add(Builders<TEntity>.Filter.Eq(filter.Field, filter.Filter));
                }
                else
                {
                    filterDefinitions.Add(Builders<TEntity>.Filter.Eq(filter.Field, filter.Filter));
                }
            }

            var combinedUpdate = Builders<TEntity>.Update.Combine(updateDefination);
            var filterDefinition = Builders<TEntity>.Filter.And(filterDefinitions);
            var a = _collection.UpdateMany(filterDefinition, combinedUpdate);

        }

        /*-------------------------------------------------------------------------------------------------------------*/
        public void UpdateWithAggregation(PipelineDefinition<TEntity, TEntity> pipeline)
        {
            var result = _collection.UpdateMany(new BsonDocument(), pipeline);
        }
        /*-------------------------------------------------------------------------------------------------------------*/ 

        public List<TEntity> GenerateAggregate(PipelineDefinition<TEntity, TEntity> pipeline)
        {
            return _collection.Aggregate(pipeline, new AggregateOptions { AllowDiskUse = true }).ToList();
        }
        /*-------------------------------------------------------------------------------------------------------------*/

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        /*-------------------------------------------------------------------------------------------------------------*/

    }
}
