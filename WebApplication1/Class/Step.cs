using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Class
{
    public class Step
    {
        
        public virtual int Id_step { get; set; }
        public virtual int Start_position_id { get; set; }
        public virtual int End_position_id { get; set; }
        public virtual string Description { get; set; }
    }
}