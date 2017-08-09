using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WebApplication1
{
    class MapFlow : ClassMapping<Flow>
    {
        public MapFlow()
        {
            Table("Flow");
            Id(x => x.id_flow, m => { m.Column("id_flow"); m.Generator(Generators.Identity); });
            Property(x => x.Value, m => { m.Column("Value"); });
            Bag(x => x.DocumentList, m =>
               {
                   m.Inverse(true); m.Key(k => k.Column("id_flow"));

               }, r => r.OneToMany(x => x.Class(typeof(Document))));
            ManyToOne(x => x.id_user, m =>
            {
                m.Column("id_user");
            });
            ManyToOne(x => x.id_attribute, m =>
            {
                m.Column("id_attribute");
            });

            ManyToOne(x => x.id_flowdefinition, m =>
            {
                m.Column("id_workflowdefinition");
            });
        }
    }
}