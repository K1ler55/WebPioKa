using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class PickFlowController : Controller
    {

        NH.NHibernateOperation operation = new NH.NHibernateOperation();
        public static User user;
        Flow flow = new Flow();
        FlowDefinition flowdef = new FlowDefinition();
        public ActionResult Index()
        {
            flowdefmodellist model = new flowdefmodellist();
            model.id_flowDefinition = -1;
            model.flowdefinitions = operation.GetList<FlowDefinition>();
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(flowdefmodellist model)
        {
            ViewBag.message = model.id_flowDefinition;
            flowdef.id_flowDefinition = model.id_flowDefinition;
            flow.id_flowdefinition = flowdef;
            flow.id_position = operation.GetPositionidFlow(model.id_flowDefinition);
            flow.id_user = user;
            flow.Name = model.name;
            operation.AddElement<Flow>(flow);
            
            return View();
        }

        



    }
}