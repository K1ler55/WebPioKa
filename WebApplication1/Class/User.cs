using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public partial class User
    {
       
        
        public int Id_user { get; set; }
        public string Surname { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage ="This field is required.")]
        public string Name { get; set; }
        public string Permission { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; }
    }
}