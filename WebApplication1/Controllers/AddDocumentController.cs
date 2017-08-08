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
<<<<<<< HEAD
        public ActionResult Add(Document document)
        {

            NH.NHibernateOperation operation = new NH.NHibernateOperation();
            if (document != null)
=======
        public ActionResult Add()
        {

            /*NH.NHibernateOperation operation = new NH.NHibernateOperation();
            if (file != null)
>>>>>>> 0f01ea1379592715afabbd87ac78b66c31ce0f19
            {
                var filename = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Datta"), filename);
                file.SaveAs(path);

                
                
            }*/
        
            return View();
        }
    }
}