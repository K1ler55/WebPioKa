using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            //informacje o uzytkowniku jakies pierdolki
            return View();
        }
        public ActionResult AddDocument()
        {
            return View();
        }
        public ActionResult Tasks()
        {
            return View();
        }
        public ActionResult DoneTasks()
        { return View(); }



    }
}