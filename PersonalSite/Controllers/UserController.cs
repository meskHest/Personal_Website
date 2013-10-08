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
using PersonalSite.Helpers;
using PersonalSite.ViewModels;
using PersonalSite.Repositories;
using System.Web.Security;

namespace PersonalSite.Controllers
{
    public class UserController : Controller
    {
        private readonly IDataRepository _dataRepository;

        public UserController()
        {

        }


        public UserController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }


        public ActionResult Authenticate(LoginUserModel model)
        {
            User usr = null;

            try
            {
               usr = _dataRepository.Query<User>(x => x.Mail == model.Mail);
            }
            catch (Exception)
            {
                
            }
            if (usr == null)
                return RedirectToAction("SignIn", "Home", null);


            if(SecurityHelper.GenerateHash(model.Password, usr.Salt) != usr.Hash)
                return RedirectToAction("SignIn", "Home", null);

            FormsAuthentication.SetAuthCookie(usr.Mail, false);
            SessionHelper.Set(usr);
            
            return RedirectToAction("Index", "Admin", null);
        }

        public ActionResult SignOut()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", null);
        }
    }
}
