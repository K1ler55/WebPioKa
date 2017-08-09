using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WebApplication1
{
    class MapFlowDefinition : ClassMapping<FlowDefinition>
    {
        public MapFlowDefinition()
        {
            Table("WorkFlowDefinition");
            Id(x => x.id_flow, m => { m.Column("id_flow"); m.Generator(Generators.Identity); });
            Property(x => x.Flow_name, m => { m.Column("flow_name"); });
            Property(x => x.Flow_description, m => { m.Column("flow_description"); });
            Bag(x => x.PositionList, m =>
            {
                m.Inverse(true); m.Key(k => k.Column("id_flow"));

            }, r => r.OneToMany(x => x.Class(typeof(Position))));

            Bag(x => x.AtributeList, m =>
            {
                m.Inverse(true); m.Key(k => k.Column("id_flow"));

            }, r => r.OneToMany(x => x.Class(typeof(Attribute))));

            Bag(x => x.DocumentList, m =>
            {
                m.Inverse(true); m.Key(k => k.Column("id_flow"));

            }, r => r.OneToMany(x => x.Class(typeof(Document))));
        }
    }
}
