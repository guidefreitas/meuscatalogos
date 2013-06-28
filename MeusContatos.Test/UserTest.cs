using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeusCatalogos.Models;
using System.Linq;
using System.Data.Entity.Validation;
using System.Transactions;
using System.Data.Entity;

namespace MeusCatalogos.Test
{
    [TestClass]
    public class UserTest : BaseTest
    {
        [TestCleanup]
        public void Cleanup()
        {
            using (var dbcontext = new MCContext())
            {
                foreach (var user in dbcontext.Users.ToList())
                {
                    dbcontext.Users.Remove(user);
                }
            }
        }

        [TestMethod]
        public void CreateUser()
        {
            using (var dbcontext = new MCContext())
            {
                User user = new User();
                user.Name = "TestUser";
                user.Email = "test@test.com";
                user.PasswordDigest = "123";
                dbcontext.Users.Add(user);
                dbcontext.SaveChanges();
                Assert.AreEqual(0, dbcontext.Entry(user).GetValidationResult().ValidationErrors.Count);
            }
        }

        [TestMethod]
        public void DeleteUser()
        {
            using (var dbcontext = new MCContext())
            {
                CreateUser();
                User user2 = dbcontext.Users.Where(x => x.Name == "TestUser").First();
                dbcontext.Entry(user2).State = System.Data.EntityState.Deleted;
                dbcontext.SaveChanges();
                Assert.AreEqual(0, dbcontext.Entry(user2).GetValidationResult().ValidationErrors.Count);
            }
        }

        [TestMethod]
        public void ValidateUserName()
        {
            using (var dbcontext = new MCContext())
            {
                User user = new User();
                user.Email = "test@test.com";

                try
                {
                    dbcontext.Users.Add(user);
                    dbcontext.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    DbEntityValidationResult eve = e.EntityValidationErrors.Where(x => x.Entry.Entity.GetType().Name == user.GetType().Name).First();
                    int valCount = eve.ValidationErrors.Where(x => x.PropertyName == "Name").Count();
                    Assert.AreEqual(1, valCount);
                }
            }
        }

        [TestMethod]
        public void ValidateUserEmail()
        {
            using (var dbcontext = new MCContext())
            {
                User user = new User();
                user.Name = "TestUser";

                try
                {
                    dbcontext.Users.Add(user);
                    dbcontext.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    DbEntityValidationResult eve = e.EntityValidationErrors.Where(x => x.Entry.Entity.GetType().Name == user.GetType().Name).First();
                    int valCount = eve.ValidationErrors.Where(x => x.PropertyName == "Email").Count();
                    Assert.AreEqual(1, valCount);
                }
            }
        }
    }
}
