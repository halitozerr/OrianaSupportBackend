using MongoDB.Driver;

namespace Core.DataAccess.Databases.MongoDB
{
    public interface IMongoDB_RawLogContext<T>
    {
        MongoClient client { get; set; }
        IMongoDatabase database { get; set; }
        IMongoDatabase GetMongoDBDatabase();
        IMongoDatabase GetMongoDBDatabase(string dataBase);
    }
}
