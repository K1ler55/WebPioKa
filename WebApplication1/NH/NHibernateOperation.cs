﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;


namespace WebApplication1.NH
{
    public class NHibernateOperation
    {
        public void AddElement<T>(T element)
        {
            using (ISession session = InitNH.OppenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(element);
                    transaction.Commit();
                }
            }
        }

       
        public List<int> GetUsersByPosition(int position)
        {
            using (ISession session = InitNH.OppenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    List<int> list = new List<int>();
                    IList<Task> tasks = session.QueryOver<Task>().Where(f => f.Id_position.Id_position == position).List();
                    foreach(Task t in tasks)
                    {
                        list.Add(t.Id_user.Id_user);
                    }
                    return list;
                }
            }
        }

        public IList<Flow> GetUserActiveFlows( Position position)
        {
            using (ISession session = InitNH.OppenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<Flow> flows = session.QueryOver<Flow>().Where(f => f.id_position.Id_position == position.Id_position).List();
                    transaction.Commit();
                    return flows;
                }
            }
        }

        public Document GetDocumentById(int id)
        {
            using (ISession session = InitNH.OppenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Document doc = session.QueryOver<Document>().Where(x => x.Id_document == id).List().First();
                    transaction.Commit();
                    return doc;
                }
            }
        }

        public Access GetAttributeAccess(int id_pos, int id_attr)
        {
            using (ISession session = InitNH.OppenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Access acc = new Access();
                    try
                    {
                        acc = session.QueryOver<Access>().Where(x => (x.Id_attributes.Id_attribute == id_attr && x.Id_position.Id_position == id_pos)).List().First();
                    }
                    catch (Exception e)
                    {
                        Console.Write(e);
                        return new Access();
                    }
                    transaction.Commit();
                    return acc;
                }
            }
        }
        public IList<Position> GetUserPositions(List<int> list)        {
            
            using (ISession session = InitNH.OppenSession())            {
                
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<Position> positionlist = session.QueryOver<Position>().WhereRestrictionOn(x => x.Id_position).IsIn(list).List();
                    transaction.Commit();
                    return positionlist;
                }
            }

        }

        public FlowExtension FindExtension(int id_flow, int id_attr)
        {
            using (ISession session = InitNH.OppenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        FlowExtension ext = session.QueryOver<FlowExtension>().Where(x => (x.id_attribute.Id_attribute == id_attr && x.id_flow.id_flow == id_flow)).List().First();
                        transaction.Commit();
                        return ext;
                    }
                    catch (Exception e)
                    {
                        return null;
                    }
                }
            }
        }
        public IList<Task> GetUserTasks (User user) 
        {
            
            using (ISession session = InitNH.OppenSession())            {
                
                using (ITransaction transaction = session.BeginTransaction())
                {        
                                        
                    IList<Task> tasklist = session.QueryOver<Task>().Where(x => x.Id_user.Id_user == user.Id_user).List();
                    transaction.Commit();
                    return tasklist;                   
                    
                }
            }
            
        }
        
       
            public  Position GetPositionidFlow(int id)
        {

            using (ISession session = InitNH.OppenSession())
            {

                using (ITransaction transaction = session.BeginTransaction())
                {

                    Position positionlist = session.QueryOver<Position>().Where(x => x.Id_position == id).List().First() ;
                    transaction.Commit();
                    
                    return positionlist;

                }
            }

        }
        public Attributes GetAttributeid(int id)
        {

            using (ISession session = InitNH.OppenSession())
            {

                using (ITransaction transaction = session.BeginTransaction())
                {

                    Attributes positionlist = session.QueryOver<Attributes>().Where(x => x.Id_attribute == id).List().First();
                    transaction.Commit();

                    return positionlist;

                }
            }

        }

        public Position FindPositionById(int id)
        {
            using (ISession session = InitNH.OppenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Position p = session.QueryOver<Position>().Where(x => x.Id_position == id).List().First();
                    transaction.Commit();
                    return p;
                }
            }
        }

        public Flow FindFlowById(int id)
        {
            using (ISession session = InitNH.OppenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Flow f = session.QueryOver<Flow>().Where(x => x.id_flow == id).List().First();
                    transaction.Commit();
                    return f;
                }
            }
        }  
        
        public IList<Attributes> GetAttributesByFlow(int id)
        {
            using (ISession session = InitNH.OppenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<Attributes> list = session.QueryOver<Attributes>().Where(x => x.Id_workflow.id_flowDefinition == id).List();
                    transaction.Commit();
                    return list;
                }
            }
        }

        public IList<ListElement> GetAttributeList(int id)
        {
            using (ISession session = InitNH.OppenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<ListElement> list = session.QueryOver<ListElement>().Where(x => x.Id_attribute.Id_attribute == id).List();
                    transaction.Commit();
                    return list;
                }
            }
        }

        public Step FindStep(Position position)
        {
            using (ISession session = InitNH.OppenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        Step step = session.QueryOver<Step>().Where(x => x.Start_position_id.Id_position == position.Id_position).List().First();
                        transaction.Commit();
                        return step;
                    } catch (Exception e)
                    {
                        return null;
                    }
                    
                }
            }
        }

        public Step FindStepById(int id)
        {
            using (ISession session = InitNH.OppenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        Step step = session.QueryOver<Step>().Where(x => x.Id_step == id).List().First();
                        transaction.Commit();
                        return step;
                    }
                    catch (Exception e)
                    {
                        return null;
                    }

                }
            }
        }

        public void Delete<T>(T element)
        {
            using (ISession session = InitNH.OppenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(element);
                    transaction.Commit();
                }
            }
        }

        public void Update<T>(T element)
        {
            using (ISession session = InitNH.OppenSession())

            {
                using (ITransaction transaction = session.BeginTransaction())

                {
                    session.Update(element);
                    transaction.Commit();
                }
            }
        }

        public IList<T> GetList<T>() where T : class
        {
            IList<T> listposition = new List<T>();
            using (ISession session = InitNH.OppenSession())

            {
                using (ITransaction transaction = session.BeginTransaction())

                {

                    listposition = session.QueryOver<T>().List();

                }

            }
            return listposition;
        }

        public IList<Attributes> GetTableAttributes(int id)
        {
            using (ISession session = InitNH.OppenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<Attributes> list = session.QueryOver<Attributes>().Where(x => x.Id_attribute == id && x.Type == "table" && x.Parent == null).List();
                    transaction.Commit();
                    return list;
                }
            }
        }
        public IList<Attributes> GetChildsAttribute(int id)
        {
            using (ISession session = InitNH.OppenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<Attributes> list = session.QueryOver<Attributes>().Where(x => x.Parent.Id_attribute  == id && x.Type == "Table").List();
                    transaction.Commit();
                    return list;
                }
            }
        }




    }
}