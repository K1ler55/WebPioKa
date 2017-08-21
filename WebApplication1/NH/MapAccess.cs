using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class MapAccess : ClassMapping<Access>
    {
        public MapAccess()
        {
            Table("Access");
            Id(x => x.Id_access, m => { m.Column("id_access"); m.Generator(Generators.Identity); });
            Property(x => x.Optional_change, m => { m.Column("optional_change"); });
            Property(x => x.Required_change, m => { m.Column("required_change"); });
            Property(x => x.Read_property, m => { m.Column("read_property"); });
            ManyToOne(x => x.Id_position, m => {
                m.Column("id_position");
            });
            ManyToOne(x => x.Id_attributes, m => {
                m.Column("id_attribute");
            });
        }
    }
}