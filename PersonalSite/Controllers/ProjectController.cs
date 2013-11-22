using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PersonalSite.Entities;
using PersonalSite.Interfaces;
using PersonalSite.ViewModels;

namespace PersonalSite.Controllers
{
    public class ProjectController : Controller
    {
        //
        // GET: /Project/
        private readonly IDataRepository _dataRepository;

        public ProjectController()
        {

        }

        public ProjectController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }


        public ActionResult ViewProject(int id)
        {
            var project = _dataRepository.Get<Project>(id);

            //var viewModel = new ProjectViewModel();


            return View(project);
        }

        public ActionResult Index()
        {

            return View();
        }
    }
}
