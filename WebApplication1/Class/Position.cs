using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Position
    {
        public virtual int Id_position { get; set; }
        public virtual FlowDefinition Id_flowDefinition { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<Step> StartStepList { get; set; }
        public virtual IList<Step> EndStepList { get; set; }
        public virtual IList<Access> Accesslist { get; set; }

        public virtual IList<Flow> FlowList { get; set; }
        public virtual IList<Task> TaskList { get; set; }
        public virtual IList<Step> StepList { get; set; }
        public virtual IList<Access> AccessList { get; set; }

    }
}