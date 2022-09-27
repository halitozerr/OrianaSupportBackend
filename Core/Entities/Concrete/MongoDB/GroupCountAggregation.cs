using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class GroupCountAggregation : MongoDBAggregation
    {

        public int Count { get; set; }
        public List<object> Ids { get; set; }
        public string DDMId { get; set; }
    }
}
