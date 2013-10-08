using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalSite.Entities
{
    public class Skill : Entity
    {
        public virtual string Name { get; set; }
        public virtual User User { get; set; }
    }
}