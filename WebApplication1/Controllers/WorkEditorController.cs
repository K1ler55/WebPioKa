using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class WorkEditorController : Controller
    {

        public static FlowDefinition flowdefinition;
        public static User user;
        public static Flow flow;
        FlowExtension flowextension = new FlowExtension();
        
        // GET: AddDocument
        public ActionResult Index()
        {
            List<string> fvalue1 = new List<string>();
            List<string> fida1 = new List<string>();
            string number = Request["number123"];
            int k = 0;
            k = Int32.Parse(number);
            for (int i = 0; i <= k; i++)
            {
               string s = "value" + i;
               string  attributeid = "id" + i;
               fvalue1.Add(Request[s]);
               fida1.Add(Request[attributeid]);
            }
            ViewBag.List = fvalue1;
            
            ViewBag.pick = flowdefinition;
            if (user == null) return RedirectToAction("Index", "Login");
            return View();
        }

        
        [HttpPost]
        public ActionResult Add(HttpPostedFileBase uploadFile)
        {
            
            
           // ViewData["MyFlow"] = flowdefinition;
            Document newDocument = new Document();
            NH.NHibernateOperation operation = new NH.NHibernateOperation();
                
            if (uploadFile != null)
            {
                string filePath = uploadFile.FileName;
                newDocument.Name = Path.GetFileName(uploadFile.FileName);
                string ext = Path.GetExtension(uploadFile.FileName);
                string contenttype = string.Empty;
                switch (ext)
                {
                    case ".doc":
                        contenttype = "application/vnd.ms-word";
                        break;
                    case ".docx":
                        contenttype = "application/vnd.ms-word";
                        break;
                    case ".pdf":
                        contenttype = "application/pdf";
                        break;
                }
                if (contenttype != String.Empty)
                {
                    byte[] bytes;
                    using (BinaryReader br = new BinaryReader(uploadFile.InputStream))
                    {
                        bytes = br.ReadBytes(uploadFile.ContentLength);
                    }
                    newDocument.Data = bytes;
                    newDocument.ContentType = contenttype;
                    operation.AddElement<Document>(newDocument);
                    return View("Index", "Account");
                }
            }
            return RedirectToAction("Index", "Account");
        }



    }







}