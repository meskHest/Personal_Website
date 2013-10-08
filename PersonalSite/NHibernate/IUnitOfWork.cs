using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;

namespace PersonalSite.NHibernate
{
        public interface IUnitOfWork : IDisposable
        {
            ISession Session { get; }
            void Commit();
            void Rollback();
        }
}