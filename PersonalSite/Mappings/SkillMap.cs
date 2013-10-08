using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using PersonalSite.Entities;

namespace PersonalSite.Mappings
{
    public class SkillMap : ClassMap<Skill>
    {
        public SkillMap()
        {
            Table("Skill");
            Id(x => x.Id);
            Map(x => x.Name);
            References(x => x.User);
        }
    }
}