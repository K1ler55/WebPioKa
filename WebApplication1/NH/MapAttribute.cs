﻿using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1
{

    class MapAttribute : ClassMapping<Attributes>
    {
        public MapAttribute()
        {
            Table("Attribute");
            Id(x => x.Id_attribute, m => { m.Column("id_attribute"); m.Generator(Generators.Identity); });
            Property(x => x.Name, m => { m.Column("name"); });
            ManyToOne(x => x.Parent, m => {
                m.Column("parent");
            });
            Property(x => x.Type, m => { m.Column("type"); });
            Bag(x => x.List, m =>
            {
                m.Inverse(true); m.Key(k => k.Column("id_attribute"));

            }, r => r.OneToMany(x => x.Class(typeof(ListElement))));

            Bag(x => x.FlowExtensionList, m =>
            {
                m.Inverse(true); m.Key(k => k.Column("id_attribute"));

            }, r => r.OneToMany(x => x.Class(typeof(FlowExtension))));
            ManyToOne(x => x.Id_workflow, m => {
                m.Column("id_workflow");
            });

            Bag(x => x.AccessList, m =>
            {
                m.Inverse(true); m.Key(k => k.Column("id_attribute"));

            }, r => r.OneToMany(x => x.Class(typeof(Access))));


        }
    }
}
