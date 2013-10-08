using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace PersonalSite.NHibernate
{
    public class MyIdConvention : IIdConvention
    {
        public void Apply(IIdentityInstance instance)
        {
            //instance.GeneratedBy.HiLo("100");
            instance.Column(instance.EntityType.Name + "Id");
        }
    }
}

