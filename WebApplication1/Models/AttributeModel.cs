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

        public List<FlowExtension> listaKarola { get; set; }

        public int? MaxRow
        {
            get
            {
                return listaKarola.OrderBy(x => x.RowIndex).Last().RowIndex;
            }
        }


    }
}