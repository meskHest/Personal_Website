using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalSite;
using PersonalSite.Entities;
using System.Linq.Expressions;
using FluentNHibernate.Data;
using FluentNHibernate.Conventions;
using PersonalSite.Interfaces;
using NHibernate;
using PersonalSite.ViewModels;
using PersonalSite.Helpers;


namespace PersonalSite.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private readonly IDataRepository _dataRepository;

        public HomeController()
        {

        }


        public HomeController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }


        public ActionResult Index()
        {
            //List<Project> lstproj = new List<Project>();
            //lstproj.Add(new Project
            //{
            //    Name = "test",
            //    Description = "Detta är ett test som man vet att man kan lita på, när laxar leker i luftballongen så vet man att det är någto sjukt jävla fel... Varför leker de inte i bollhavet?",
            //    Client = "nill",
            //    CoverImg = "",
            //    Created = DateTime.Now
            //});
            //lstproj.Add(new Project
            //{
            //    Name = "test2",
            //    Description = "Detta är ett andra test som avslöjar sälar som sympatiserar med sovjet!",
            //    Client = "nill",
            //    CoverImg = "",
            //    Created = DateTime.Now
            //});
            //lstproj.Add(new Project
            //{
            //    Name = "test3",
            //    Description = "Det mest extrema test som är testigt värre, man kan undra om datorn har skrivit detta själv... eller?",
            //    Client = "nill",
            //    CoverImg = "",
            //    Created = DateTime.Now
            //});

            //foreach (Project p in lstproj)
            //{
            //    if (p.Description.Length > 80)
            //    {
            //        p.Caption = p.Description.Substring(0, 80) + "...";
            //    }
            //    else
            //    {
            //        p.Caption = p.Description;
            //    }
            //}


            //List<Skill> lstskill = new List<Skill>();
            //lstskill.Add(new Skill
            //{
            //    Name = "C# .Net"
            //});
            //lstskill.Add(new Skill
            //{
            //    Name = "Webforms"
            //});
            //lstskill.Add(new Skill
            //{
            //    Name = "MVC"
            //});
            //lstskill.Add(new Skill
            //{
            //    Name = "Ajax"
            //});
            //lstskill.Add(new Skill
            //{
            //    Name = "HTML"
            //});
            //lstskill.Add(new Skill
            //{
            //    Name = "CSS"
            //});
            //lstskill.Add(new Skill
            //{
            //    Name = "jQuery"
            //});
            //lstskill.Add(new Skill
            //{
            //    Name = "RavenDB"
            //});
            //lstskill.Add(new Skill
            //{
            //    Name = "SQL Server"
            //});


            //var salt = SecurityHelper.CreateSalt();
            //var u = _dataRepository.Save<User>(new User
            //{
            //    Mail = "olsson.j.fredrik@gmail.com",
            //    Name = "Fredrik Olsson",
            //    Title = "Web / System developer",
            //    Employer = "Unemployed",
            //    HomeTown = "Varberg",
            //    Country = "Sweden",
            //    Skills = lstskill,
            //    Projects = lstproj,
            //    Salt = salt,
            //    Hash = SecurityHelper.GenerateHash("Password", salt),
            //});

            User usr = _dataRepository.Get<User>(1);

            CardContent card = new CardContent
            {
                Title = usr.Title,
                Name = usr.Name,
                Mail = usr.Mail,
                Hometown = usr.HomeTown,
                Country = usr.Country,
                Skills = usr.Skills.ToList(),
                Employer = usr.Employer
            };

            var viewModel = new StartViewModel();
            viewModel.LatestProjects = GetLatestProjects();
            viewModel.Projects = GetRestProjects();
            viewModel.Card = card;

            ViewBag.Card = card;
            ViewBag.Projects = usr.Projects;
            return View(viewModel);
        }

        public ActionResult SignIn()
        {
            return View();
        }


        public ActionResult ViewProject(int Id)
        {
            var project = _dataRepository.Get<Project>(Id);
            return View();
        }



        #region Helpers

        public List<Project> GetLatestProjects()
        {
            var listOfProject = _dataRepository.All<Project>().ToList();
            if (listOfProject.Count > 3)
                listOfProject = listOfProject.OrderByDescending(project => project.Created).Take(3).ToList();

            return listOfProject;
        }

        public List<Project> GetRestProjects()
        {
            var listOfProject = _dataRepository.All<Project>().OrderByDescending(project => project.Created).Skip(3).ToList();
            return listOfProject;
        }


        #endregion

    }
}




// ADD STUFF TO DB
