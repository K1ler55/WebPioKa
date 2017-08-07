using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            NH.InitNH init = new NH.InitNH();
            init.InitNHibernate();


            return View();
        }
        [HttpPost]
        public ActionResult Autherize(WebApplication1.User Marcin)
        {
             NH.NHibernateOperation operation = new NH.NHibernateOperation();
            IList<User> lists = operation.GetList<User>();
            foreach(User u in lists){
                if (u.Name.Equals( Marcin.Name) && u.Password.Equals( Marcin.Password))
                {
                    Session["userID"] = u.Id_user;
                    return RedirectToAction("Index", "Account");
                }
                else
               
                return View("Index", Marcin);

            }

            return View();
        }
    }
}