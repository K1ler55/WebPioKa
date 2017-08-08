using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Step
    {
        
        public virtual int Id_step { get; set; }
        public virtual Position Start_position_id { get; set; }
        public virtual Position End_position_id { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<Step> StepConditionList { get ; set ; }
    }
}