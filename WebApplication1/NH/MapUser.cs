using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WebApplication1
{
    public class MapUser : ClassMapping<User>
    {
        public MapUser()
        {

            Table("Users");
            Id(x => x.Id_user, m => { m.Column("id_user"); m.Generator(Generators.Identity); });
            Property(x => x.Name, m => { m.Column("name"); });
            Property(x => x.Surname, m => { m.Column("surname"); });
            Property(x => x.Email, m => { m.Column("email"); });
            Property(x => x.Permission, m => { m.Column("permission"); });
            Property(x => x.Password, m => { m.Column("password"); });           

            Bag(x => x.FlowList, m =>
            {
                m.Inverse(true); m.Key(k => k.Column("id_user"));

            }, r => r.OneToMany(x => x.Class(typeof(Flow))));

            Bag(x => x.TaskList, m =>
            {
                m.Inverse(true); m.Key(k => k.Column("id_user"));

            }, r => r.OneToMany(x => x.Class(typeof(Task))));
        }
    }
}