using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Class
{
    public class Workflow
    {
        public virtual int Flow_id { get; set; }
        public virtual string Flow_name { get; set; }
        public virtual string Flow_description { get; set; }
    }
}