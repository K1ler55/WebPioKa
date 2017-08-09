using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class TasksController : Controller
    {
        // GET: Tasks
        public static User user;
        private IList<Step> steplist = new List<Step>();
        
        public ActionResult Index()
        {
            if (user == null) return RedirectToAction("Index", "Login");

            NH.NHibernateOperation operation = new NH.NHibernateOperation();
            steplist = operation.GetUserTasks(user);            

            ViewBag.List = steplist;
            return View();
        }

        public ActionResult Execute(int number)
        {
            if (user == null) return RedirectToAction("Index", "Login");
            NH.NHibernateOperation operation = new NH.NHibernateOperation();

            Position pos = operation.GetUserPosition(user);
            Flow flow = operation.GetUserFlow(pos);
            IList<Document> docs = operation.GetUserDocuments(flow);

            ViewBag.Documents = (docs == null ? new List<Document>() : docs);
            ViewBag.Number = number;
            return View();
        }
    }
}