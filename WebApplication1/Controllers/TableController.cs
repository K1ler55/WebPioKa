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
            atrmodel.flowextension = new List<FlowExtension>();
            flowdef.id_flowDefinition = 83;
            atrmodel.atributechilds = operation.GetChildsAttribute(atrmodel.Id_attribute);
            atrmodel.Attributeslist = operation.GetTableAttributes(flowdef.id_flowDefinition);
            IList<FlowExtension> listapomoc = new List<FlowExtension>();
            foreach (var item in atrmodel.atributechilds)
            {
                listapomoc = operation.flowextensionAttributesTable(1072, item.Id_attribute);
                foreach (var i in listapomoc)
                {
                    atrmodel.flowextension.Add(i);
                }
            }
            return View("Index",atrmodel);
        }
        [HttpPost]
        public ActionResult Pickchild(AttributeModel atrmodel)
        {

            return View("Index", atrmodel);
        }
     /*   [HttpPost]
        public ActionResult Create(AttributeModel model)
        {
            model.flowextension = operation.GetList<FlowExtension>();
            foreach (var item in model.atributechilds)
            {

            model.flowextension.Add(new FlowExtension());
             model.flowextension.Last().id_attribute = item;
                model.flowextension.Last().id_flow = flow;
            }
            return View("Index", model);
        }*/

    }
}