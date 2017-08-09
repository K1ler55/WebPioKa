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
        public static User user;
        public static FlowDefinition flow;
        // GET: AddDocument
        public ActionResult Index()
        {
            if (user == null) return RedirectToAction("Index", "Login");
            return View();
        }

        
        [HttpPost]
        public ActionResult Add(HttpPostedFileBase uploadFile)
        {
           

            string flowvalue = Request["testSelect"];
            Document newDocument = new Document();
            NH.NHibernateOperation operation = new NH.NHibernateOperation();
            newDocument.Id_user = user;

            IList<FlowDefinition> flowlist = new List<FlowDefinition>();
            flowlist = operation.GetList<FlowDefinition>();
            foreach (FlowDefinition i in flowlist)
            {
                if (i.id_flow == Int32.Parse(flowvalue))
                {
                    newDocument.Id_flow = i;
                }
            }
           
                
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