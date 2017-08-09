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

            Dictionary<Position, IList<Step>> map = new Dictionary<Position, IList<Step>>();
            NH.NHibernateOperation operation = new NH.NHibernateOperation();
            IList<Position> positions = operation.GetUserPosition(user);
            
            foreach(Position p in positions)
            {
                map.Add(p, operation.GetUserTasks(p));
            }

            ViewBag.Map = map;
            return View();
        }

        public ActionResult Execute(int id_position,int number)
        {
            if (user == null) return RedirectToAction("Index", "Login");
            NH.NHibernateOperation operation = new NH.NHibernateOperation();

            
            return View();
        }
    }
}