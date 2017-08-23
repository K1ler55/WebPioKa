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
            User user = (User)Session["users"];
            if (user == null) return RedirectToAction("Index", "Login");
            return View();
        }
        public ActionResult PickFlow()
        {
            return RedirectToAction("Index", "PickFlow");
        }
        public ActionResult Tasks()
        {
            return RedirectToAction("Index", "Tasks");
        }
        public ActionResult DoneTasks() {
            return RedirectToAction("Index", "DoneTasks"); }

        public ActionResult Document()
        {
            return RedirectToAction("Index", "Document");
        }

        public ActionResult Table()
        {
            return RedirectToAction("Index", "Table");
        }



    }
}