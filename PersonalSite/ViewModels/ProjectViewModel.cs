using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalSite.Entities;

namespace PersonalSite.ViewModels
{
    public class ProjectViewModel
    {
        public string Name { get; set; }
        public string Client { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string CoverImage { get; set; }
        public string Ingress { get; set; }
    }
}