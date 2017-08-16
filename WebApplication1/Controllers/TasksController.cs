using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Xml;


namespace WebApplication1.Controllers
{
    public class TasksController : Controller
    {
        // GET: Tasks
        
        private IList<Step> steplist = new List<Step>();
        
        public ActionResult Index()
        {
            User user = (User)Session["users"];
            if(user == null) return RedirectToAction("Index", "Login");         
            
            Dictionary<Position, IList<Flow>> map = new Dictionary<Position, IList<Flow>>();
            NH.NHibernateOperation operation = new NH.NHibernateOperation();

            IList<Task> tasks = operation.GetUserTasks(user);
            List<int> numbers = new List<int>();

            foreach(Task t in tasks)
            {
                numbers.Add(t.Id_position.Id_position);
            }

            IList<Position> positions = operation.GetUserPositions(numbers);
            
            foreach(Position p in positions)
            {
                map.Add(p, operation.GetUserActiveFlows(p));
            }

            IList<Attributes> list = operation.GetAttributesByFlow(70);

            List<IList<ListElement>> dict = new List<IList<ListElement>>();

            foreach(Attributes a in list)
            {
                if (a.Type.Equals("list"))
                {                    
                    dict.Add(operation.GetAttributeList(a.Id_attribute));
                }
            }
            Document doc = operation.GetDocumentById(15);
            byte[] data = doc.Data;

            ViewBag.Map = map;
            ViewBag.List = list;
            ViewBag.Attr = dict;
            return View();
        }

        public ActionResult Execute(int number)
        {
            string id = (string)RouteData.Values["id"];
            int position = Int32.Parse(id);
            User user = (User)Session["users"];
            if (user == null) return RedirectToAction("Index", "Login");
            NH.NHibernateOperation operation = new NH.NHibernateOperation();

            List<int> users = operation.GetUsersByPosition(position);
            if (!users.Contains(user.Id_user)) ViewBag.Result = 403;

            Position p = operation.FindPositionById(position);
            IList<Flow> flows = operation.GetUserActiveFlows(p);
            foreach(Flow f in flows)
            {
                if (f.id_flow == number) ViewBag.Flow = f;
            }

            Document doc = operation.GetDocumentById(12);
            byte[] data = doc.Data;
            string str = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);
            IHtmlString html = new HtmlString(str);

            




            ViewBag.Tekst = str;
            return View();
        }

        public static string ConvertHexToString(String hexInput, System.Text.Encoding encoding)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return encoding.GetString(bytes);
        }


        public ActionResult Change()
        {
            User user = (User)Session["users"];
            if (user == null) return RedirectToAction("Index", "Login");

            NH.NHibernateOperation operation = new NH.NHibernateOperation();

            string id = (string)RouteData.Values["id"];
            int f= Int32.Parse(id);
            Flow flow = operation.FindFlowById(f);

            Position p = operation.FindPositionById(flow.id_position.Id_position);

            Step step = operation.FindStep(p);            

            flow.id_position = step.End_position_id;
            operation.Update<Flow>(flow);
            return View();
        }
    }
}