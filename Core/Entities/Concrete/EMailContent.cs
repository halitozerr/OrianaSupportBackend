using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class EMailContent
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; }
    }
}
