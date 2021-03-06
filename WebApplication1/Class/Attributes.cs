﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Attributes
    {

        public virtual int Id_attribute { get; set; }
        public virtual Attributes Parent { get; set; }
        public virtual FlowDefinition Id_workflow { get; set; }
        public virtual string Name { get; set; }
        public virtual string Type { get; set; }
        public virtual IList<ListElement> List { get; set; }

        public virtual IList<FlowExtension> FlowExtensionList { get; set; }
        public virtual IList<Access> AccessList { get; set; }
    }
}