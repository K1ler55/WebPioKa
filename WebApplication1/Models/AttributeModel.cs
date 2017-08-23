using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AttributeModel
    {
        public int Id_attribute { get; set; }
        public IList<Attributes> atributechilds { get; set; }
        public IList<Attributes> Attributeslist { get; set; }

        public IList<FlowExtension> flowextension { get; set; }


    }
}