using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalSite.Entities;

namespace PersonalSite.ViewModels
{
    public class StartViewModel
    {
        public CardContent Card { get; set; }
        public List<Project> Projects { get; set; }
        public List<Project> LatestProjects { get; set; }
        
    }
}