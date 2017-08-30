using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Xml;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Dynamic;
using WebApplication1.Models;
using WorkFlowDesigner;
using System.Xml.Serialization;

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

            NH.NHibernateOperation operation = new NH.NHibernateOperation();

            IList<Task> tasks = operation.GetUserTasks(user);
            List<int> numbers = new List<int>();

            foreach (Task t in tasks)
            {
                numbers.Add(t.Id_position.Id_position);
            }

            IList<Position> positions = operation.GetUserPositions(numbers);

            Dictionary<Position, IList<Flow>> map = new Dictionary<Position, IList<Flow>>();

            foreach (Position p in positions)
            {
                map.Add(p, operation.GetUserActiveFlows(p));
            }
            TaskModel task = new TaskModel();
            task.Map = map;
            ViewBag.Task = task;
            
            //List<string[]> list = parser.Condition(cond);
            

            return View();
            
        }
        
        public Item findItem(string name, Items items)
        {
            foreach(Item item in items.itemList)
            {
                if (item.id.name.Equals(name)) return item;
            }
            return null;
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
            Flow flow = new Flow();
            foreach (Flow f in flows)
            {
                if (f.id_flow == number)
                {
                    ViewBag.Flow = f;
                    flow = f;
                    break;
                }
            }
            FlowDefinition fl = operation.GetFlowDefinition(flow.id_flowdefinition.id_flowDefinition);
            Document doc = operation.GetDocumentByName(fl.Flow_name);
            byte[] data = doc.Data;
            string str2 = System.Text.Encoding.UTF8.GetString(data, 0, data.Length);
            string sub = str2.Substring(1);

            XmlSerializer deserializer = new XmlSerializer(typeof(Items));
            XmlDocument docxml = new XmlDocument();
            docxml.LoadXml(sub);
            XmlNodeReader node = new XmlNodeReader(docxml);
            object obj = deserializer.Deserialize(node);
            Items XmlData = (Items)obj;
            node.Close();
            Dictionary<string, Item> itemMap = new Dictionary<string, Item>();
            foreach(Item it in XmlData.itemList)
            {
                if(it.id.name.Equals("Item "))
                {
                    it.id.name = "check";
                }
                itemMap.Add(it.id.name, it);
            }

            IList<Attributes> attrList = operation.GetAttributesByFlow(flow.id_flowdefinition.id_flowDefinition);
            FullFlowModel model = new FullFlowModel();
            model.list = new List<FlowModel<string>>();
            model.list_int = new List<FlowModel<int>>();
            model.values = new List<string>();
            model.items = XmlData;
            foreach (Attributes a in attrList)
            {

                Access acc = operation.GetAttributeAccess(position, a.Id_attribute);
                if(acc.Read_property==1 && (acc.Required_change==1 || acc.Optional_change == 1))
                {
                    if (a.Type.Equals("int"))
                    {
                        FlowModel<int> f = new FlowModel<int>();
                        f.name = a.Name;
                        f.required = acc.Required_change;
                        f.type = a.Type;
                        f.item = itemMap[a.Name];
                        model.list_int.Add(f);
                    } 
                    else
                    {
                        FlowModel<string> f = new FlowModel<string>();
                        f.name = a.Name;
                        f.required = acc.Required_change;
                        f.type = a.Type;
                        f.item = itemMap[a.Name];
                        if (a.Type.Equals("list"))
                        {
                            IList<ListElement> ll = operation.GetAttributeList(a.Id_attribute);
                            List<string> str = new List<string>();
                            str.Add(null);
                            foreach(ListElement l in ll)
                            {
                                str.Add(l.Name);
                            }
                            f.list = str;
                        }
                        model.list.Add(f);
                    }
                    
                } else if(acc.Read_property ==1)
                {
                    FlowExtension ext = operation.FindExtension(flow.id_flow, a.Id_attribute);
                    if(ext!=null) model.values.Add(a.Id_attribute.ToString() + " = "+ext.Value);
                }
                
            }
            ViewBag.Test = model;

            int max = 0;
            foreach(Item i in XmlData.itemList)
            {
                if ((i.location.y + i.size.height) > max)
                {
                    max = (i.location.y + i.size.height);
                }
            }

            max = max + 70;
            ViewBag.Max = max.ToString()+"px";

            ViewBag.Tekst = "";

            return View(model);
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

        [HttpPost]
        public ActionResult Change(FullFlowModel model)
        {
            User user = (User)Session["users"];
            if (user == null) return RedirectToAction("Index", "Login");

            NH.NHibernateOperation operation = new NH.NHibernateOperation();

            string id = (string)RouteData.Values["id"];
            int f= Int32.Parse(id);
            Flow flow = operation.FindFlowById(f);

            Position p = operation.FindPositionById(flow.id_position.Id_position);
            ViewBag.Pos = p.Id_position;
            Step step = operation.FindStep(p);         
            ViewBag.Model = model;

            if (step != null)
            {
                flow.id_position = step.End_position_id;

                String cond = step.Condition;
                if (cond != null)
                {
                    Parser parser = new Parser();
                    string[] list = parser.Parse(cond);
                    Dictionary<string, string> dict = new Dictionary<string, string>();

                    foreach (FlowModel<string> mdl in model.list)
                    {
                        dict.Add(mdl.name, mdl.value);
                    }
                    foreach (FlowModel<int> mdl in model.list_int)
                    {
                        dict.Add(mdl.name, mdl.value.ToString());
                    }

                    List<bool> bool_list = new List<bool>();
                    List<string> sign = new List<string>();
                    foreach (string s in list)
                    {
                        string temp = s;
                        char start = s[0];
                        char end = s[s.Length - 1];
                        string str = "";
                        string en = "";

                        if (start.Equals("|") || start.Equals("&"))
                        {
                            temp = s.Substring(2, s.Length - 2);
                            str = "" + start + start;
                            sign.Add(str);
                        }
                        if (end.Equals("|") || end.Equals("&"))
                        {
                            temp = temp.Substring(0, temp.Length - 2);
                            en = "" + end + end;
                            sign.Add(en);
                        }

                        bool result = parser.checkBracket(temp, dict);
                        bool_list.Add(result);
                    }

                    bool wynik = bool_list[0];
                    for (int i = 0; i < sign.Count; i++)
                    {
                        if (sign.Equals("||"))
                        {
                            wynik = wynik || bool_list[i + 1];
                        }
                        else
                        {
                            wynik = wynik && bool_list[i + 1];
                        }
                    }

                    if (wynik == true)
                    {
                        MailController mm = new MailController();
                        

                        IList<Task> tasks = operation.GetTasksByPositionId(step.End_position_id);
                        foreach (Task t in tasks)
                        {
                            ModelMail mdl = new ModelMail();
                            mdl.from = "noreply.opteam@gmail.com";
                            User us = operation.GetUserById(t.Id_user.Id_user);
                            mdl.to = us.Email;
                            mdl.subject = "Nowe zadanie";
                            mdl.value = " Masz nowe zadanie wejdz na konto i sprawdz";
                            mm.sendMail(mdl);
                        }
                        //AddElements(flow, model);
                        //operation.Update<Flow>(flow);
                    }
                    // JESLI NIE SPELNI WARUNKOW TO ROB CO INNEGO
                }
                else
                {
                    MailController mm = new MailController();
                    IList<Task> tasks = operation.GetTasksByPositionId(step.End_position_id);
                    foreach (Task t in tasks)
                    {
                        ModelMail mdl = new ModelMail();
                        mdl.from = "noreply.opteam@gmail.com";
                        User us = operation.GetUserById(t.Id_user.Id_user);
                        mdl.to = us.Email;
                        mdl.subject = "Nowe zadanie";
                        mdl.value = " Masz nowe zadanie wejdz na konto i sprawdz";
                        mm.sendMail(mdl);
                    }
                    //AddElements(flow, model);
                    //operation.Update<Flow>(flow);
                }

            } else
            {
                flow.id_position = null;
                //AddElements(flow, model);
                //operation.Update<Flow>(flow);
            }
            return View();
        }

        public void AddElements(Flow flow, FullFlowModel model)
        {
            NH.NHibernateOperation operation = new NH.NHibernateOperation();
            for (int i = 0; i < model.list.Count; i++)
            {
                Attributes a = operation.FindAttributeByName(model.list[i].name);
                createExtension(flow, a, model.list[i].value);
            }
            for (int i = 0; i < model.list_int.Count; i++)
            {
                Attributes a = operation.FindAttributeByName(model.list_int[i].name);
                createExtension(flow, a, model.list_int[i].value.ToString());
            }
        }
        
        public void createExtension(Flow id_flow, Attributes id_attr,string value)
        {
            FlowExtension ext = new FlowExtension();
            ext.id_flow = id_flow;
            ext.id_attribute = id_attr;
            ext.Value = value;
            NH.NHibernateOperation operation = new NH.NHibernateOperation();
            operation.AddElement<FlowExtension>(ext);
        }
    }
}