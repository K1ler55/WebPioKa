using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AddDocumentController : Controller
    {
        // GET: AddDocument
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add(HttpPostedFileBase file)
        {
            NH.NHibernateOperation operation = new NH.NHibernateOperation();
            if (file != null)
            {
                var filename = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Datta"), filename);
                file.SaveAs(path);
                
                
            }
        
            return View();
        }
    }
}