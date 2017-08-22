using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DocumentModel
    {
        public string name { get; set; }
        public int id_document { get; set; }
        public virtual string ContentType { get; set; }
        public virtual byte[] Data { get; set; }
        public IEnumerable<Document> Documents { get; set; }
    }
}