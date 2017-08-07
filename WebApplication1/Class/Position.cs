using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Class
{
    public class Position
    {
        public virtual int Id_position { get; set; }
        public virtual int Id_flow { get; set; }
        public virtual string Name { get; set; }
    }
}