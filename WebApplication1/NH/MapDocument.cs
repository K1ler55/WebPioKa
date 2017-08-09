using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate;

namespace WebApplication1
{
    class MapDocument : ClassMapping<Document>
    {
        public MapDocument()
        {
            Table("Document");
            Id(x => x.Id_document, m => { m.Column("id_document"); m.Generator(Generators.Identity); });
            Property(x => x.Data, m => { m.Column("Data"); m.Length(Int32.MaxValue); });
            Property(x => x.ContentType, m => { m.Column("ContentType"); });
            Property(x => x.Name ,m => { m.Column("name"); });
            ManyToOne(x => x.Id_flow, m =>
            {
                m.Column("id_flow");
            });
        }
    }
}
