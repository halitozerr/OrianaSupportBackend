using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Core.Entities.Concrete
{
    public class MongoDBAggregation : IEntity
    {
      
        public string Id { get; set; }
    }
}
