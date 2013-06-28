using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeusCatalogos.Models;
using System.Data.Entity.Validation;
using System.Linq;

namespace MeusCatalogos.Test
{
    [TestClass]
    public class CatalogItemTest
    {
        public void Setup()
        {
            using (var dbcontext = new MCContext())
            {
                Company company = new Company
                {
                    Name = "CompanyTest"
                };

                User user = new User()
                {
                    Name = "UserTest",
                    Email = "test@test.com",
                    PasswordDigest = "123"
                };

                ItemCategory category = new ItemCategory()
                {
                    Name = "CategoryTest"
                };

                dbcontext.Companies.Add(company);
                dbcontext.Users.Add(user);
                dbcontext.ItemCategories.Add(category);
                dbcontext.SaveChanges();
            }
        }

        [TestMethod]
        public void CreateCatalogWithItens()
        {
            using (var dbcontext = new MCContext())
            {
                try
                {
                    Setup();

                    Catalog catalog = new Catalog()
                    {
                        Name = "CatalogTest",
                        Company = dbcontext.Companies.Where(x => x.Name == "CompanyTest").First(),
                        UserCreated = dbcontext.Users.Where(x => x.Name == "UserTest").First(),
                    };

                    

                    CatalogItem item = new CatalogItem()
                    {
                        Name = "ProductTest",
                        Description = "Description productTest",
                        Price = new Decimal(10.0),
                        Category = dbcontext.ItemCategories.Where(x => x.Name == "CategoryTest").First(),
                    };

                    catalog.Itens.Add(item);
                    dbcontext.Catalogs.Add(catalog);

                    dbcontext.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    Assert.Fail("Tried to save invalid objects");
                }
                


            }
        }

        [TestMethod]
        public void RemoveItemFromCatalog()
        {
            using (var dbcontext = new MCContext())
            {
                try
                {
                    Setup();
                    Catalog catalog = new Catalog()
                    {
                        Name = "CatalogTest",
                        Company = dbcontext.Companies.Where(x => x.Name == "CompanyTest").First(),
                        UserCreated = dbcontext.Users.Where(x => x.Name == "UserTest").First(),
                    };

                    CatalogItem item = new CatalogItem()
                    {
                        Name = "ProductTest",
                        Description = "Description productTest",
                        Price = new Decimal(10.0),
                        Category = dbcontext.ItemCategories.Where(x => x.Name == "CategoryTest").First(),
                    };

                    catalog.Itens.Add(item);
                    dbcontext.Catalogs.Add(catalog);

                    dbcontext.SaveChanges();

                    CatalogItem itemDb = catalog.Itens.First();
                    catalog.Itens.Remove(itemDb);
                    dbcontext.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    Assert.Fail("Tried to save invalid objects");
                }
            }
        }
    }
}
