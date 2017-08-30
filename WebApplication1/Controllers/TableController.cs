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
        List<FlowExtension> listapomoc = new List<FlowExtension>();
        FlowExtension flowex = new FlowExtension();
        public static User user;
        
        // GET: Table
        public ActionResult Index()
        {
            if (user == null) return RedirectToAction("Index", "Login");

            AttributeModel model = new AttributeModel();
           
                flowdef.id_flowDefinition = 83;
                model.Attributeslist = operation.GetTableAttributes(flowdef.id_flowDefinition);
                model.Id_attribute = -1;
                model.atributechilds = new List<Attributes>();
                
                
                

            return View(model);
        }
        [HttpPost]
        public ActionResult PickTable(AttributeModel atrmodel)
        {
            if (atrmodel.pomocnicza == null)
            {
                
                atrmodel.pomocnicza = new List<FlowExtension>();
            }
            FlowExtension flowex = new FlowExtension();
            flow.id_flow = 1072;
            flowdef.id_flowDefinition = 83;
            if (atrmodel.atributechilds == null)
            {
                atrmodel.atributechilds = operation.GetChildsAttribute(atrmodel.Id_attribute);
                atrmodel.Attributeslist = operation.GetTableAttributes(flowdef.id_flowDefinition);
            }
           if(atrmodel.flowextensionlist == null)
              {
                atrmodel.flowextensionlist = new List<FlowExtension>();
                atrmodel.flowextensionlist = operation.flowextensionAttributesTable(1072, atrmodel.atributechilds);
                atrmodel.MaxRow= atrmodel.flowextensionlist.OrderBy(x => x.RowIndex).Last().RowIndex; 
            }
            if (Request.Form["Add"] != null)
            {
                
                for (int i = 0; i < atrmodel.atributechilds.Count; i++)
                {
                    flowex.id_attribute = atrmodel.atributechilds[i];
                    flowex.id_flow = flow;
                    flowex.Value="";
                    flowex.RowIndex = atrmodel.MaxRow +1;
                    operation.AddElement<FlowExtension>(flowex);
                }
                atrmodel.flowextensionlist = operation.flowextensionAttributesTable(1072, atrmodel.atributechilds);

                foreach (var item in atrmodel.atributechilds)
                {

                    atrmodel.flowextensionlist = operation.flowextensionAttributesTable(1072, atrmodel.atributechilds);
                    atrmodel.MaxRow = atrmodel.flowextensionlist.OrderBy(x => x.RowIndex).Last().RowIndex;

                }
                return View("Index", atrmodel);
            }
            if (Request.Form["newValue"] != null)
            {
                
                for (int items = 0; items < atrmodel.pomocnicza.Count; items++)
                {

                    flowex=operation.Flowextension(atrmodel.pomocnicza[items].id_flowextension);
                    flowex.Value = atrmodel.pomocnicza[items].Value;
                    operation.Update<FlowExtension>(flowex);
                }
                
            }
                 
            
            if (Request.Form["Delete"] != null)
            {

            }
                return View("Index",atrmodel);
        }
        
      

    }
}