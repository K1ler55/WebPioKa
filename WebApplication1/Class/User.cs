using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WebApplication1
{
    public class User
    {
        

        public int Id_user { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Permission { get; set; }
        public string Password { get; set; }
    }
}