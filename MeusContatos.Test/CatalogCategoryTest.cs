using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeusCatalogos.Models;
using System.Linq;
using System.Data.Entity.Validation;

namespace MeusCatalogos.Test
{
    [TestClass]
    public class CatalogCategoryTest
    {
        [TestMethod]
        public void CreateCatalogCategory()
        {
            using (var dbcontext = new MCContext())
            {
                try
                {
                    CatalogCategory category = new CatalogCategory();
                    category.Name = "CategoryTest";
                    dbcontext.CatalogCategories.Add(category);
                    dbcontext.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    Assert.Fail("Tried to save invalid objects");
                }
            }
        }

        [TestMethod]
        public void DeleteCatalogCategory()
        {
            using (var dbcontext = new MCContext())
            {
                try
                {
                    CatalogCategory category = new CatalogCategory();
                    category.Name = "CategoryTest";
                    dbcontext.CatalogCategories.Add(category);
                    dbcontext.SaveChanges();

                    dbcontext.CatalogCategories.Remove(category);
                    dbcontext.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    Assert.Fail("Tried to save invalid objects");
                }
            }
        }

        [TestMethod]
        public void ValidateCatalogCategoryName()
        {
            using (var dbcontext = new MCContext())
            {
                CatalogCategory category = new CatalogCategory();
                try
                {
                    dbcontext.CatalogCategories.Add(category);
                    dbcontext.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    DbEntityValidationResult eve = e.EntityValidationErrors.Where(x => x.Entry.Entity.GetType().Name == category.GetType().Name).First();
                    int valCount = eve.ValidationErrors.Where(x => x.PropertyName == "Name").Count();
                    Assert.AreEqual(1, valCount);
                }
            }
        }
    }
}
