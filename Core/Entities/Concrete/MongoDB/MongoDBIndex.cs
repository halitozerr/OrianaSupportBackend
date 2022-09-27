using System.Collections.Generic;

namespace Core.Entities.Concrete.MongoDB
{
    public class MongoDBIndex
    {
        public int v { get; set; }
        public Dictionary<string, int> key { get; set; }
        public string name { get; set; }
    }
}
