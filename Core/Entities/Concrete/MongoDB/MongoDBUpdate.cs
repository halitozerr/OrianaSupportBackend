using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
   public class MongoDBUpdate
    {
        public string Field { get; set; }
        public object NewValue { get; set; }
    }
}
