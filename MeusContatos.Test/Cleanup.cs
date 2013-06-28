using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeusCatalogos.Models;
using System.Data.Entity.Validation;
using System.Transactions;
using System.Data.Entity;

namespace MeusCatalogos.Test
{
    public class Cleanup
    {
        public static void ClearAllTables()
        {
            ClearImages();
            ClearCatalogItens();
            ClearCatalogs();
            ClearCompanies();
            ClearUsers();
        }

        public static void ClearUsers()
        {
            using (var dbcontext = new MCContext())
            {
                foreach (var user in dbcontext.Users.ToList())
                {
                    dbcontext.Users.Remove(user);
                }
            }
        }

        public static void ClearCompanies()
        {
            using (var dbcontext = new MCContext())
            {
                foreach (var obj in dbcontext.Companies.ToList())
                {
                    dbcontext.Companies.Remove(obj);
                }
            }
        }

        public static void ClearCatalogs()
        {
            using (var dbcontext = new MCContext())
            {
                foreach (var obj in dbcontext.Catalogs.ToList())
                {
                    dbcontext.Catalogs.Remove(obj);
                }
            }
        }

        public static void ClearCatalogItens()
        {
            using (var dbcontext = new MCContext())
            {
                foreach (var obj in dbcontext.CatalogItens.ToList())
                {
                    dbcontext.CatalogItens.Remove(obj);
                }
            }
        }

        public static void ClearImages()
        {
            using (var dbcontext = new MCContext())
            {
                foreach (var obj in dbcontext.Images.ToList())
                {
                    dbcontext.Images.Remove(obj);
                }
            }
        }
    }
}
