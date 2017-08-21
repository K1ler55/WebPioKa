using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
 
    public class flowdefmodellist
    {
        public string name { get; set; }
        public int id_flowDefinition { get; set; }
       
        public IEnumerable<FlowDefinition> flowdefinitions { get; set; }
    }
}