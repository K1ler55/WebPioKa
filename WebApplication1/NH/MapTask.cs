using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1 
{
    public class MapTask : ClassMapping<Task>
    {
        public MapTask()
        {
            Table("Tasks");
            Id(x => x.Id_task, m => { m.Column("id_task"); m.Generator(Generators.Identity); });

            ManyToOne(x => x.Id_position, m =>
            {
                m.Column("id_position");
            });

            ManyToOne(x => x.Id_user, m =>
            {
                m.Column("id_user");
            });
        }  
        
    }
}