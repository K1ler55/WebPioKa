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

            return RedirectToAction("Index", "AddDocument");
        }
        public ActionResult Tasks()
        {
            return RedirectToAction("Index", "Tasks");
        }
        public ActionResult DoneTasks() {
            return RedirectToAction("Index", "DoneTasks"); }



    }
}