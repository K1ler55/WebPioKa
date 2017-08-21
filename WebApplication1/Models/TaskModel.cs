using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class TaskModel
    {
        private Dictionary<Position, IList<Flow>> map = new Dictionary<Position, IList<Flow>>();
        public Dictionary<Position, IList<Flow>> Map { get; set; }
    }
}