using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class DatabaseConnection
    {
        public virtual int Id_connection { get; set; }
        public virtual string Name { get; set; }

        public virtual string Server { get; set; }
        public virtual string Database { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }

    }
}