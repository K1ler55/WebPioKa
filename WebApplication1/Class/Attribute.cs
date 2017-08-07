using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Class
{
    public class Attribute
    {
        
        public virtual int Id_attribute { get; set; }
        public virtual int Id_workflow { get; set; }
        public virtual string Name { get; set; }
        public virtual string Type { get; set; }
    }
}