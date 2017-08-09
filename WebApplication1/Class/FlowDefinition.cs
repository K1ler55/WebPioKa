﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class FlowDefinition
    {
        public virtual int id_flowDefinition { get; set; }
        public virtual string Flow_name { get; set; }
        public virtual string Flow_description { get; set; }
        public virtual IList<Attribute> AtributeList { get; set; }
        public virtual IList<Position> PositionList { get ; set; }

        public virtual IList<Flow> FlowList { get; set; }

    }
}