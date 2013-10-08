using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalSite.Entities;

namespace PersonalSite.Helpers
{
    public class SessionHelper
    {
        private const string Key = "User";

        public static User Get()
        {
            var session = HttpContext.Current.Session;
            try
            {
                if (session[Key] != null)
                {
                    return (User)session[Key];
                }
            }
            catch (Exception)
            {
            }
            return new User();
        }

        public static void Set(User user)
        {
            var session = HttpContext.Current.Session;
            try
            {
                session[Key] = user;
            }
            catch (Exception)
            {
            }
        }

        public static void Clear()
        {
            Set(new User());
        }

    }
}