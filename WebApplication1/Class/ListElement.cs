﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class ListElement
    {
        
        public virtual int Id_list_element { get; set; }
        public virtual string Name { get; set; }
        public virtual Attributes Id_attribute { get; set; }
    }
}