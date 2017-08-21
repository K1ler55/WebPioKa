using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    
    public class FlowModel<T>
    {
       public string name { get; set; } 
       public string type { get; set; }
       public T value { get; set; }
       public int required { get; set; }       
    }    

    public class FullFlowModel
    {
        public List<FlowModel<string>> list { get; set; }
        public List<FlowModel<int>> list_int { get; set; }
        public List<string> values { get; set; }

        public int id { get; set; }

        
    }
}