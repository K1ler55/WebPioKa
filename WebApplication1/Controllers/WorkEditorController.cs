﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class WorkEditorController : Controller
    {
        NH.NHibernateOperation operation = new NH.NHibernateOperation();
        public static FlowDefinition flowdefinition;
        public static User user;
        public static Flow flow;
        Attributes attribute = new Attributes();
        FlowExtension flowextension = new FlowExtension();
        
        // GET: AddDocument
        public ActionResult Index()
        { 
            if (user == null) return RedirectToAction("Index", "Login");
            
            
            return View();
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
            return RedirectToAction("Index", "Account");
        }
        
    }







}