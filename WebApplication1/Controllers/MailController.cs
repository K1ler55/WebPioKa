using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            User user = (User)Session["users"];
            if (user == null) return RedirectToAction("Index", "Login");

            MailModel model = new MailModel();
            NH.NHibernateOperation operation = new NH.NHibernateOperation();
            model.userList = operation.GetList<User>();
            return View(model);
        }

        [HttpPost]
        public ActionResult Send(MailModel model)
        {
            User user = (User)Session["users"];
            if (user == null) return RedirectToAction("Index", "Login");
            ModelMail mail = new ModelMail();
            NH.NHibernateOperation operation = new NH.NHibernateOperation();
            User u = operation.GetUserById(model.Id_user);
            mail.from = user.Email;
            mail.to = u.Email;        
            
            return View(mail);
        }

        [HttpPost]
        public ActionResult Sending(ModelMail model)
        {
            sendMail(model);
            return View();
        }

        public void sendMail(ModelMail model)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("noreply.opteam@gmail.com", "$Opteam$");

            MailMessage mm = new MailMessage(model.from, model.to, model.subject, model.value);
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            client.Send(mm);
        }
    }
}