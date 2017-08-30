using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ModelMail
    {
        public string subject { get; set; }
        public string value { get; set; }
        public string from { get; set; }
        public string to { get; set; }
    }
    public class MailModel
    {
        public string Name { get; set; }
        public int Id_user { get; set; }
        public IEnumerable<User> userList { get; set; }
    }
}