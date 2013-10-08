using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalSite.Entities;

namespace PersonalSite.ViewModels
{
    public class CardContent
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Title { get; set; }
        public string Hometown { get; set; }
        public string Country { get; set; }
        public List<Skill> Skills { get; set; }
        public string Employer { get; set; }
    }
}