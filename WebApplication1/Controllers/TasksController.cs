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
        
        private IList<Step> steplist = new List<Step>();
        
        public ActionResult Index()
        {
            User user = (User)Session["users"];
            if(user == null) return RedirectToAction("Index", "Login");         
            
            Dictionary<Position, IList<Flow>> map = new Dictionary<Position, IList<Flow>>();
            NH.NHibernateOperation operation = new NH.NHibernateOperation();
            IList<Position> positions = operation.GetUserPosition(user);
            
            foreach(Position p in positions)
            {
                map.Add(p, operation.GetUserActiveFlows(p));
            }

            ViewBag.Map = map;
            return View();
        }

        public ActionResult Execute(int position,int number)
        {
            User user = (User)Session["users"];
            if (user == null) return RedirectToAction("Index", "Login");
            NH.NHibernateOperation operation = new NH.NHibernateOperation();

            IList<User> users = operation.GetUsersByPosition(position);

            /*if (user.Id_position.Id_position != position)
            {
                ViewBag.Result = 403;
            }*/            
            
            

            
            return View();
        }
    }
}