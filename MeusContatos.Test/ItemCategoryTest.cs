using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeusCatalogos.Models;
using System.Linq;
using System.Data.Entity.Validation;

namespace MeusCatalogos.Test
{
    [TestClass]
    public class ItemCategoryTest
    {
        [TestMethod]
        public void CreateItemCategory()
        {
            using (var dbcontext = new MCContext())
            {
                try
                {
                    ItemCategory category = new ItemCategory();
                    category.Name = "CategoryTest";
                    dbcontext.ItemCategories.Add(category);
                    dbcontext.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    Assert.Fail("Tried to save invalid objects");
                }
            }
        }

        [TestMethod]
        public void DeleteItemCategory()
        {
            using (var dbcontext = new MCContext())
            {
                try
                {
                    ItemCategory category = new ItemCategory();
                    category.Name = "CategoryTest";
                    dbcontext.ItemCategories.Add(category);
                    dbcontext.SaveChanges();

                    dbcontext.ItemCategories.Remove(category);
                    dbcontext.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    Assert.Fail("Tried to save invalid objects");
                }
            }
        }

        [TestMethod]
        public void ValidateItemCategoryName()
        {
            using (var dbcontext = new MCContext())
            {
                ItemCategory category = new ItemCategory();
                try
                {
                    dbcontext.ItemCategories.Add(category);
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
