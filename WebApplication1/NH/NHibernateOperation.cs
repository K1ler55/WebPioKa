
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



    }
}