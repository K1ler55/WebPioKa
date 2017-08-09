using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class PickFlowController : Controller
    {
        FlowDefinition flowdefinition =  new FlowDefinition();
        Flow flow = new Flow();
        public static User user;
        public ActionResult Index()
        {
            if (user == null) return RedirectToAction("Index", "Login");
            return View();            
        }
        public ActionResult GetFlow()
        {
            string flowvalue = Request["testSelect"];
            flowdefinition.id_flowDefinition = Int32.Parse(flowvalue);
            flow.id_flow = flowdefinition.id_flowDefinition;
            WorkEditorController.flow = flow;
            return RedirectToAction("Index", "WorkEditor"); ;
        }
    }
}