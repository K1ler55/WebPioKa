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
            flowdef.id_flowDefinition = 46;
            atrmodel.Attributeslist = operation.GetTableAttributes(flowdef.id_flowDefinition);
            atrmodel.Id_attribute = -1;
            atrmodel.atributechilds = new List<Attributes>();
            atrmodel.flowextension = new List<FlowExtension>();

            return View(atrmodel);
        }
        [HttpPost]

        public ActionResult PickTable(AttributeModel model)
        {
            flowdef.id_flowDefinition = 46;
            model.atributechilds = operation.GetChildsAttribute(model.Id_attribute);
            model.Attributeslist = operation.GetTableAttributes(flowdef.id_flowDefinition);
            model.flowextension = operation.GetList<FlowExtension>();
            return View("Index",model);
        }
        [HttpPost]
        public ActionResult Pickchild(AttributeModel model)
        {
            
            return View("Index", model);
        }
        [HttpPost]
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
        }

    }
}