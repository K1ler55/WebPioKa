﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public  class User
    {
       
        
        public virtual int Id_user { get; set; }
        public virtual string Surname { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage ="This field is required.")]
        public virtual string Name { get; set; }
        public virtual string Permission { get; set; }
        public virtual string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public virtual string Password { get; set; }        
        
        public virtual IList<Flow> FlowList { get; set; }
        public virtual IList<Task> TaskList { get; set; }
    }
}