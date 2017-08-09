using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Flow
    {
        public virtual int id_flow { get; set; }
        
        public virtual string Value { get; set; }
        public virtual User id_user { get; set; }
        public virtual Attribute id_attribute { get; set; }
        public virtual FlowDefinition id_flowdefinition{ get; set; }

        public virtual IList<Document> DocumentList { get; set; }

    }
}