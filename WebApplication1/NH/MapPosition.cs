﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace WebApplication1
{
    public class MapPosition : ClassMapping<Position>
    {
        public MapPosition()
        {

            Table("Position");
            Id(x => x.Id_position, m => { m.Column("id_position"); m.Generator(Generators.Identity); });
            Property(x => x.Name, m => { m.Column("name"); });
            ManyToOne(x => x.Id_flowDefinition, m =>
            {
                m.Column("id_flow");
            });
            Bag(x => x.StartStepList, m =>
            {
                m.Inverse(true); m.Key(k => k.Column("id_position"));

            }, r => r.OneToMany(x => x.Class(typeof(Step))));
            Bag(x => x.EndStepList, m =>
            {
                m.Inverse(true); m.Key(k => k.Column("id_position"));

            }, r => r.OneToMany(x => x.Class(typeof(Step))));
            Bag(x => x.Accesslist, m =>
            {
                m.Inverse(true); m.Key(k => k.Column("id_position"));

            }, r => r.OneToMany(x => x.Class(typeof(Access))));



            Bag(x => x.FlowList, m =>
            {
                m.Inverse(true); m.Key(k => k.Column("id_position"));

            }, r => r.OneToMany(x => x.Class(typeof(Flow))));

            Bag(x => x.TaskList, m =>
            {
                m.Inverse(true); m.Key(k => k.Column("id_task"));

            }, r => r.OneToMany(x => x.Class(typeof(Task))));
            Bag(x => x.StepList, m =>
            {
                m.Inverse(true); m.Key(k => k.Column("id_position"));

            }, r => r.OneToMany(x => x.Class(typeof(Step))));


        }

    }
}
