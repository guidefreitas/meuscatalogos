using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeusCatalogos.Models;
using System.Linq;
using System.Data.Entity.Validation;

namespace MeusCatalogos.Test
{
    [TestClass]
    public class CompanyTest : BaseTest
    {
        [TestMethod]
        public void CreateCompany()
        {
            using (var dbcontext = new MCContext())
            {
                try
                {
                    Company company = new Company();
                    company.Name = "TestCompany";
                    dbcontext.Companies.Add(company);
                    dbcontext.SaveChanges();
                    Assert.AreEqual(0, dbcontext.Entry(company).GetValidationResult().ValidationErrors.Count);
                }
                catch (DbEntityValidationException e)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void DeleteCompany()
        {
            using (var dbcontext = new MCContext())
            {
                CreateCompany();
                Company company = dbcontext.Companies.Where(x => x.Name == "TestCompany").First();
                dbcontext.Companies.Remove(company);
                Assert.AreEqual(0, dbcontext.Entry(company).GetValidationResult().ValidationErrors.Count);
            }
        }

        [TestMethod]
        public void ValidateCompanyName()
        {
            using (var dbcontext = new MCContext())
            {
                Company company = new Company();
                try
                {
                    dbcontext.Companies.Add(company);
                    dbcontext.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    DbEntityValidationResult eve = e.EntityValidationErrors
                        .Where(x => x.Entry.Entity.GetType().Name == company.GetType().Name)
                        .First();

                    int valCount = eve.ValidationErrors.Where(x => x.PropertyName == "Name").Count();
                    Assert.AreEqual(1, valCount);
                }
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (var dbcontext = new MCContext())
            {
                foreach (var c in dbcontext.Companies.ToList())
                {
                    dbcontext.Companies.Remove(c);
                }
            }
        }
    }
}
