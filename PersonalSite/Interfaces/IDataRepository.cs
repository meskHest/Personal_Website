using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalSite.Interfaces
{
    public interface IDataRepository : IRepository
    {
        TEntity Get<TEntity>(int id);
    }
}