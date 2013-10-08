using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using PersonalSite.Entities;

namespace PersonalSite.Mappings
{
    public class ProjectMap: ClassMap<Project>
    {
        public ProjectMap()
        {
            Table("Project");
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Client);
            Map(x => x.Description);
            Map(x => x.Created);
            Map(x => x.Caption);
            Map(x => x.Url);
            References(x => x.User);
            HasMany(x => x.Gallery);
            HasOne(x => x.CoverImg);
        }
    }
}