using System;
using System.Collections.Generic;

namespace PersonalSite.Entities
{
    public class Project : Entity
    {
        public virtual string Name { get; set; }
        public virtual string Client { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual string Caption { get; set; }
        public virtual User User { get; set; }
        public virtual string Url { get; set; }
        public virtual string Ingress { get; set; }
        public virtual string CoverImg { get; set; }
        public virtual IEnumerable<Image> Gallery { get; set; } 
    }
}