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
            ViewBag.User = user;
            return View();
        }
        public ActionResult PickFlow()
        {
            User user = (User)Session["users"];
            if (user == null) return RedirectToAction("Index", "Login");
            return RedirectToAction("Index", "PickFlow");
        }
        public ActionResult Tasks()
        {
            User user = (User)Session["users"];
            if (user == null) return RedirectToAction("Index", "Login");
            return RedirectToAction("Index", "Tasks");
        }
        public ActionResult DoneTasks() {
            return RedirectToAction("Index", "DoneTasks"); }

        public ActionResult Document()
        {
            User user = (User)Session["users"];
            if (user == null) return RedirectToAction("Index", "Login");
            return RedirectToAction("Index", "Document");
        }

        public ActionResult Table()
        {
            User user = (User)Session["users"];
            if (user == null) return RedirectToAction("Index", "Login");
            return RedirectToAction("Index", "Table");
        }

        public ActionResult Mail()
        {
            User user = (User)Session["users"];
            if (user == null) return RedirectToAction("Index", "Login");
            return RedirectToAction("Index", "Mail");
        }

    }
}