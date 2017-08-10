using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class PickFlowController : Controller
    {
        NH.NHibernateOperation operation = new NH.NHibernateOperation();
        FlowDefinition flowdefinition = new FlowDefinition();
        Flow flow = new Flow();
        Position position = new Position();
        public static User user;
        public ActionResult Index()
        {
            if (user == null) return RedirectToAction("Index", "Login");
            return View();
        }
        public ActionResult GetFlow()
        {
            string flowvalue = Request["testSelect"];
            string flowname =  Request["testFlow"];
            string positionvalue = Request["PositionSelect"];
            flowdefinition.id_flowDefinition = Int32.Parse(flowvalue);
            WorkEditorController.flowdefinition = flowdefinition;
            flow.id_flowdefinition = flowdefinition;
            flow.Name = flowname;
            flow.id_user = user;
            flow.id_position.Id_position = Int32.Parse(positionvalue);
            operation.AddElement<Flow>(flow);
            return RedirectToAction("Index", "WorkEditor"); ;
        }
    }
}