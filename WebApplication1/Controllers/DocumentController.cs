using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class DocumentController : Controller
    {
        NH.NHibernateOperation operation = new NH.NHibernateOperation();
        public ActionResult Index()
        {
            DocumentModel documentmodel = new DocumentModel();
            documentmodel.id_document = -1;
            documentmodel.Documents= operation.GetList<Document>();
            return View(documentmodel);
        }

        [HttpPost]
        public ActionResult Add(HttpPostedFileBase uploadFile)
        {


            // ViewData["MyFlow"] = flowdefinition;
            Document newDocument = new Document();


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
            return RedirectToAction("Index", "Document");
        }
        [HttpPost]
        public FileResult Download(DocumentModel documentmodel)
        { int id=documentmodel.id_document;
            Document document = new Document();
            document= operation.GetDocumentById(id);
            return File(document.Data, document.ContentType, document.Name);
        }

    }
}