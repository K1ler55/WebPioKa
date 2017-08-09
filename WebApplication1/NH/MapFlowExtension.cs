using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WebApplication1
{
    class MapFlowExtension : ClassMapping<FlowExtension>
    {
        public MapFlowExtension()
        {
            Table("FlowExtension");
            Id(x => x.id_flowextension, m => { m.Column("id_flowextension"); m.Generator(Generators.Identity); });
            Property(x => x.Value, m => { m.Column("Value"); });
            Bag(x => x.documentList, m =>
            {
                m.Inverse(true); m.Key(k => k.Column("id_flowextension"));

            }, r => r.OneToMany(x => x.Class(typeof(Document))));
            ManyToOne(x => x.id_attribute, m =>
            {
                m.Column("id_attribute");

            });
            ManyToOne(x => x.id_flow, m =>
            {
                m.Column("id_flow");
            });
        }
    }
}
