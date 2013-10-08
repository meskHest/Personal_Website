using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using PersonalSite.Entities;

namespace PersonalSite.Mappings
{
    public class ImageMap : ClassMap<Image>
    {
        public ImageMap()
        {
            Table("Image");
            Id(x => x.Id);
            Map(x => x.Url);
        }

    }
}