using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AttributeModel
    {
        public int Id_attribute { get; set; }
        public List<Attributes> atributechilds { get; set; }
        public List<Attributes> Attributeslist { get; set; }
        public List<FlowExtension> flowextensionlist { get; set; }
        public List<FlowExtension> pomocnicza { get;set; }

        public List<FlowExtension> pomocnicza2 { get; set; }

        public Nullable<int> MaxRow
        {
            get;set;
        }


    }
}