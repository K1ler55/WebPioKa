using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Class
{
    public class StepCondition
    {
        public virtual int Id_stepcondition { get; set; }
        public virtual int Id_step { get; set; }
        public virtual string Condition { get; set; }
    }
}