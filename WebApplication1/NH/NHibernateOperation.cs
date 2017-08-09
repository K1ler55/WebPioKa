
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

        public Position GetUserPosition(User user)
        {
            using (ISession session = InitNH.OppenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Position pos = session.QueryOver<Position>().Where(type => type.Id_position == user.Id_position.Id_position).List().First();
                    transaction.Commit();
                    return pos;
                }
            }
        }

        public Flow GetUserFlow ( Position position)
        {
            using (ISession session = InitNH.OppenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    Flow flow = session.QueryOver<Flow>().Where(p => p.Flow_id == position.Id_flow.Flow_id).List().First();
                    transaction.Commit();
                    return flow;
                }
            }
        }

        public IList<Document> GetUserDocuments(Flow flow)
        {
            using (ISession session = InitNH.OppenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IList<Document> docs = session.QueryOver<Document>().Where(p => p.Id_flow.id_flow == flow.id_flow).List();
                    transaction.Commit();
                    return docs;
                }
            }
        }

        public IList<Step> GetUserTasks (User user) 
        {
            
            using (ISession session = InitNH.OppenSession())
            {
                IList<StepCondition> list = new List<StepCondition>();
                using (ITransaction transaction = session.BeginTransaction())
                {          
                    Position pos = session.QueryOver<Position>().Where(type => type.Id_position == user.Id_position.Id_position).List().First();
                                        
                    IList<Step> steplist = session.QueryOver<Step>().Where(type => type.Start_position_id.Id_position == pos.Id_position).List();
                    transaction.Commit();


                    return steplist;                   
                    
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