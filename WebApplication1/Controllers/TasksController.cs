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
        private IList<String> tasks;
        public ActionResult Index()
        {

            tasks = new List<String>();
            for(int i = 0; i < 5; i++)
            {
                tasks.Add("Zadanie " + i);
            }
            ViewBag.Tasks = tasks;
            return View();
        }

        public ActionResult Execute(int number)
        {

            return View();
        }
    }
}