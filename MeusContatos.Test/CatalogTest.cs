using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeusCatalogos.Models;
using System.Linq;
using System.Data.Entity.Validation;
using MeusCatalogos.Test;

namespace MeusContatos.Test
{
    [TestClass]
    public class MeusCatalogos : BaseTest
    {
        [TestMethod]
        public void CreateCatalog()
        {
            using (var dbcontext = new MCContext())
            {
                Catalog catalog = new Catalog();
                catalog.Name = "TestCatalog";
                dbcontext.Catalogs.Add(catalog);
                dbcontext.SaveChanges();
                Assert.AreEqual(0, dbcontext.Entry(catalog).GetValidationResult().ValidationErrors.Count);
            }
        }

        [TestMethod]
        public void DeleteCatalog()
        {
            using (var dbcontext = new MCContext())
            {
                CreateCatalog();
                Catalog catalog = dbcontext.Catalogs.Where(x => x.Name == "TestCatalog").First();
                dbcontext.Catalogs.Remove(catalog);
                Assert.AreEqual(0, dbcontext.Entry(catalog).GetValidationResult().ValidationErrors.Count);
            }
        }

        [TestMethod]
        public void ValidateCatalogName()
        {
            using (var dbcontext = new MCContext())
            {
                Catalog catalog = new Catalog();
                try
                {
                    dbcontext.Catalogs.Add(catalog);
                    dbcontext.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    DbEntityValidationResult eve = e.EntityValidationErrors
                        .Where(x => x.Entry.Entity.GetType().Name == catalog.GetType().Name)
                        .First();

                    int valCount = eve.ValidationErrors.Where(x => x.PropertyName == "Name").Count();
                    Assert.AreEqual(1, valCount);
                }
            }
        }
    }
}
