using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class TableController : Controller
    {
        NH.NHibernateOperation operation = new NH.NHibernateOperation();
        FlowDefinition flowdef = new FlowDefinition();
        Flow flow = new Flow();
        public static User user;
        
        // GET: Table
        public ActionResult Index()
        {
            if (user == null) return RedirectToAction("Index", "Login");
            AttributeModel atrmodel = new AttributeModel();
            flow.id_flow = 1072;
            flowdef.id_flowDefinition = 83;
            atrmodel.Attributeslist = operation.GetTableAttributes(flowdef.id_flowDefinition);
            atrmodel.Id_attribute = -1;
            atrmodel.atributechilds = new List<Attributes>();
            
            return View(atrmodel);
        }
        [HttpPost]

        public ActionResult PickTable(AttributeModel atrmodel)
        {
            flow.id_flow = 1072;
            atrmodel.flowextension = new List<FlowExtension>();
            FlowExtension flowex = new FlowExtension();
            flowdef.id_flowDefinition = 83;
            atrmodel.atributechilds = operation.GetChildsAttribute(atrmodel.Id_attribute);
            atrmodel.Attributeslist = operation.GetTableAttributes(flowdef.id_flowDefinition);
            IList<FlowExtension> listapomoc = new List<FlowExtension>();
           if(atrmodel.listaKarola==null)
              {
                atrmodel.listaKarola = new List<IList<FlowExtension>>();
                foreach (var item in atrmodel.atributechilds)
                {
                    listapomoc = operation.flowextensionAttributesTable(1072, item.Id_attribute);
                    atrmodel.listaKarola.Add(listapomoc);
                }
            }
            if (Request.Form["Add"] != null)
            {
                
                for (int i = 0; i < atrmodel.atributechilds.Count; i++)
                {
                    flowex.id_attribute = atrmodel.atributechilds[i];
                    flowex.id_flow = flow;
                    flowex.Value = "test";
                    operation.AddElement<FlowExtension>(flowex);
                }
                foreach (var item in atrmodel.atributechilds)
                {

                    listapomoc = operation.flowextensionAttributesTable(1072, item.Id_attribute);
                    atrmodel.listaKarola.Add(listapomoc);

                }

            }
            if (Request.Form["newValue"] != null)
            {
                for (int i = 0; i < atrmodel.listaKarola.ElementAt(0).Count; i++)
                {
                    for (int item = 0; item < atrmodel.listaKarola.Count; item++)
                    {
                        flowex.id_attribute = atrmodel.listaKarola.ElementAt(item).ElementAt(i).id_attribute;
                        flowex.id_flow = atrmodel.listaKarola.ElementAt(item).ElementAt(i).id_flow;
                        flowex.id_flowextension= atrmodel.listaKarola.ElementAt(item).ElementAt(i).id_flowextension;
                        flowex.Value = atrmodel.listaKarola.ElementAt(item).ElementAt(i).Value;

                        operation.Update<FlowExtension>(flowex);
                        
                    }
                } 
            }
                return View("Index",atrmodel);
        }
        
      

    }
}