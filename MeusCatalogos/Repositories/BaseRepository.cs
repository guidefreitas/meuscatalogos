using MeusCatalogos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MeusCatalogos.Repositories
{
    public class BaseRepository : IDisposable, IBaseRepository
    {
        protected MCContext dbcontext;
        public BaseRepository()
        {
            dbcontext = new MCContext();
        }

        public void Dispose()
        {
            dbcontext.Dispose();
        }

        public void SaveChanges()
        {
            dbcontext.SaveChanges();
        }

        public void Discard()
        {
            dbcontext = new MCContext();
        }
    }
}