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

            IList<Task> tasks = operation.GetUserTasks(user);
            List<int> numbers = new List<int>();

            foreach(Task t in tasks)
            {
                numbers.Add(t.Id_position.Id_position);
            }

            IList<Position> positions = operation.GetUserPositions(numbers);
            
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

            List<int> users = operation.GetUsersByPosition(position);
            if (!users.Contains(user.Id_user)) ViewBag.Result = 403;

            Position p = operation.FindPositionById(position);
            IList<Flow> flows = operation.GetUserActiveFlows(p);
            ViewBag.Flow = flows[number];

            return View();
        }

        public ActionResult Change()
        {

            return View();
        }
    }
}