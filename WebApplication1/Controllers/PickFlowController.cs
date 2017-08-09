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
        public static User user;
        public ActionResult Index()
        {
            string flowvalue = Request["testSelect"];
            flowdefinition.id_flowDefinition = Int32.Parse(flowvalue);
            WorkEditorController.flow = flowdefinition;

            return View("Index","WorkEditor");
        }
    }
}