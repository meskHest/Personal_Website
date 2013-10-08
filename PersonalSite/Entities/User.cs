using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalSite.Entities
{
    public class User: Entity
    {
        public virtual string Name { get; set; }
        public virtual string Mail { get; set; }
        public virtual string Title { get; set; }
        public virtual string Employer { get; set; }
        public virtual IEnumerable<Skill> Skills { get; set; }
        public virtual IEnumerable<Project> Projects { get; set; }
        public virtual string HomeTown { get; set; }
        public virtual string Country { get; set; }
        public virtual string Hash { get; set; }
        public virtual string Salt { get; set; }
    }
}