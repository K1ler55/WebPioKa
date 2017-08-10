using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class Task
    {
        public virtual int Id_task { get; set; }
        public virtual User Id_user { get; set; }
        public virtual Position Id_position { get; set; }
    }
}