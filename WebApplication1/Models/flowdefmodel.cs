using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class flowdefmodel
    {
        public Int32 id_flowDefinition { get; set; }
        public IEnumerable<FlowDefinition> flowdefinitions { get; set; }
    }
}