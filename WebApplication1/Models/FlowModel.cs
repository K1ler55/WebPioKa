using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1
{
    
    public class FlowModel<T>
    {
        private bool value_bool;
       public string name { get; set; } 
       public string type { get; set; }
       public T value { get; set; }
       public int required { get; set; }       
       public List<string> list { get; set; }
        public Item item { get; set; }
        public bool Value_bool 
        {
            get
            {
                return value_bool;
            }
            set
            {
                value_bool = value;
                if (value_bool == true)
                {
                    this.value = (T)(object)"true";
                }
                else
                {
                    this.value = (T)(object)"false";
                }
            }
        }
    }    

    public class FullFlowModel
    {
        
        public List<FlowModel<string>> list { get; set; }
        public List<FlowModel<int>> list_int { get; set; }
        public List<string> values { get; set; }
        public int id { get; set; }
        public Items items { get; set; }

        
    }
}