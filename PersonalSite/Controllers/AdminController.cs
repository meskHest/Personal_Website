using System;
using System.Collections.Generic;
using System.IO;
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
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IDataRepository _dataRepository;

        public AdminController()
        {

        }


        public AdminController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        //
        // GET: /Admin/

        public ActionResult Index()
        {
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


            ViewBag.Card = card;
            ViewBag.Projects = usr.Projects;
            return View();
        }

        public ActionResult DeleteProject(int id)
        {
            var proj = _dataRepository.Get<Project>(id);
            _dataRepository.Delete<Project>(proj);

            return RedirectToAction("Index");
        }

        public ActionResult AddProject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProject(ProjectViewModel p, HttpPostedFileBase CoverImage)
        {
            string fileName = "noImage.png";
            string capt;

            if (p.Description.Length > 80)
            {
                capt = p.Description.Substring(0, 80) + "...";
            }
            else
            {
                capt = p.Description;
            }


            if (CoverImage != null && CoverImage.ContentLength > 0)
            {
                fileName = Path.GetFileName(CoverImage.FileName);
                var path = Path.Combine(Server.MapPath("~/Upload"), fileName);
                CoverImage.SaveAs(path);
            }



            var id = _dataRepository.Save<Project>(new Project
            {
                Name = p.Name,
                Created = DateTime.Now,
                Client = p.Client,
                Description = p.Description,
                Ingress = p.Ingress,
                Caption = capt,
                CoverImg = fileName,
                User = _dataRepository.Query<User>(x => x.Mail == User.Identity.Name)
            });

            return RedirectToAction("Index");
        }

        public ActionResult EditProject(int id)
        {
            var proj = _dataRepository.Get<Project>(id);

            var viewModel = new ProjectViewModel
            {
                Client = proj.Client,
                Description = proj.Description,
                Name = proj.Name
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditProject(ProjectViewModel p, int id)
        {

            string capt;

            if (p.Description.Length > 80)
            {
                capt = p.Description.Substring(0, 80) + "...";
            }
            else
            {
                capt = p.Description;
            }

            var projectToUpdate = _dataRepository.Get<Project>(id);
            projectToUpdate.Name = p.Name;
            projectToUpdate.Client = p.Client;
            projectToUpdate.Description = p.Description;
            projectToUpdate.Ingress = p.Ingress;
            projectToUpdate.Caption = capt;

            _dataRepository.Update(projectToUpdate);

            return RedirectToAction("Index");
        }

        public ActionResult EditUser()
        {
            var u = _dataRepository.Query<User>(x => x.Mail == User.Identity.Name);

            var viewModel = new CardContent
            {
                Country = u.Country,
                Employer = u.Employer,
                Hometown = u.HomeTown,
                Mail = u.Mail,
                Name = u.Name,
                Skills = u.Skills.ToList(),
                Title = u.Title
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult EditUser(CardContent c)
        {
            var u = _dataRepository.Query<User>(x => x.Mail == User.Identity.Name);

            u.Title = c.Title;
            u.Mail = c.Mail;
            u.HomeTown = c.Hometown;
            u.Employer = c.Employer;
            u.Country = c.Country;
            u.Name = c.Name;

            var triggerUpdate = _dataRepository.Update<User>(u);

            return RedirectToAction("Index");
        }


    }
}
