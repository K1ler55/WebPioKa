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
        flowdefmodel model = new flowdefmodel();
        public static User user;
        
        public ActionResult Index()
        {
            model.flowdefinitions = operation.GetList<FlowDefinition>();
            return View(model);
        }
      
        public string Pickthisflow(int id)
        {
            id = model.id_flowDefinition;
            return "Selected flow is: " + id.ToString();
;        }

    }
}