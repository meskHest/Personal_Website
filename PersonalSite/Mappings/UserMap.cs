using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using PersonalSite.Entities;

namespace PersonalSite.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table("Users");
            Id(x => x.Id);
            Map(x => x.Country);
            Map(x => x.Employer);
            Map(x => x.Hash);
            Map(x => x.HomeTown);
            Map(x => x.Mail);
            Map(x => x.Name);
            Map(x => x.Salt);
            HasMany(x => x.Skills).Cascade.All();
            Map(x => x.Title);
            HasMany(x => x.Projects).Cascade.All();
        }
    }
}