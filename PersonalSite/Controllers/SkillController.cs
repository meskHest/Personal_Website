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
    public class SkillController : Controller
    {
                        private readonly IDataRepository _dataRepository;

        public SkillController()
        {

        }


        public SkillController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        //
        // GET: /Skill/

        [HttpPost]
        public JsonResult Delete(int? id)
        {
            var bla = id;

            var sk = _dataRepository.Query<Skill>(x => x.Id == id);
            var triggerDelete = _dataRepository.Delete<Skill>(sk);

            return Json(id);
        }

        [HttpPost]
        public JsonResult Add(string name)
        {
            var bla = name;
            if (name == null)
                name = "error";


            var id = _dataRepository.Save<Skill>(new Skill { 
            Name = name,
            User = _dataRepository.Query<User>(x => x.Mail == User.Identity.Name)
            });
            

            return Json(new { Id = id, Name = name });
        }

    }
}
