using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public class Document
    {

        public virtual int Id_document { get; set; }
        
        public virtual string Name { get; set; }
        public virtual string Permission { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public virtual string Password { get; set; }
    }
}