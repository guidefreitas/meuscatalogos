using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeusCatalogos.Repositories;
using MeusCatalogos.Models;
using System.Collections.Generic;

namespace MeusCatalogos.Test
{
    [TestClass]
    public class UserRepositoryTest
    {
        [TestCleanup]
        public void Cleanup()
        {
            MeusCatalogos.Test.Cleanup.ClearAllTables();
        }

        [TestCategory("Repositories")]
        [TestMethod]
        public void InsertUserRepositoryTest()
        {
            using (var repo = new UserRepository())
            {
                User user = new User();
                user.Name = "TestUser";
                user.Email = "test@test.com";
                user.PasswordDigest = "123";
                repo.Insert(user);
                repo.SaveChanges();
            }
        }

        [TestCategory("Repositories")]
        [TestMethod]
        public void DeteleUserRepositoryTest()
        {
            using (var repo = new UserRepository())
            {
                User user = new User();
                user.Name = "TestUser";
                user.Email = "test@test.com";
                user.PasswordDigest = "123";
                repo.Insert(user);
                repo.SaveChanges();
                User userdb = repo.FindById(user.UserId);
                repo.Delete(userdb);
            }
        }

        [TestMethod]
        public void DeteleUserByIdRepositoryTest()
        {
            using (var repo = new UserRepository())
            {
                User user = new User();
                user.Name = "TestUser";
                user.Email = "test@test.com";
                user.PasswordDigest = "123";
                repo.Insert(user);
                repo.SaveChanges();
                User userdb = repo.FindById(user.UserId);
                repo.Delete(userdb.UserId);
            }
        }

        [TestMethod]
        public void FindByIdUserRepositoryTest()
        {
            using (var repo = new UserRepository())
            {
                User user = new User();
                user.Name = "TestUser";
                user.Email = "test@test.com";
                user.PasswordDigest = "123";
                repo.Insert(user);
                repo.SaveChanges();
                User userdb = repo.FindById(user.UserId);
                Assert.IsNotNull(userdb);
            }
        }

        [TestMethod]
        public void FindByNameUserRepositoryTest()
        {
            using (var repo = new UserRepository())
            {
                User user = new User();
                user.Name = "TestUser";
                user.Email = "test@test.com";
                user.PasswordDigest = "123";
                repo.Insert(user);
                repo.SaveChanges();
                User userdb = repo.FindByName(user.Name);
                Assert.IsNotNull(userdb);
            }
        }

        [TestMethod]
        public void FindByEmailUserRepositoryTest()
        {
            using (var repo = new UserRepository())
            {
                User user = new User();
                user.Name = "TestUser";
                user.Email = "test@test.com";
                user.PasswordDigest = "123";
                repo.Insert(user);
                repo.SaveChanges();
                User userdb = repo.FindByEmail(user.Email);
                Assert.IsNotNull(userdb);
            }
        }

        [TestMethod]
        public void TransactionUserRepositoryTest()
        {
            using (var repo = new UserRepository())
            {
                User user = new User();
                user.Name = "TestUser";
                user.Email = "test@test.com";
                user.PasswordDigest = "123";
                repo.Insert(user);
                repo.SaveChanges();

                user.Name = "ModifiedUserName";
                repo.SaveChanges();

                User userdb = repo.FindByName("ModifiedUserName");
                Assert.AreEqual(user.UserId, userdb.UserId);
            }
        }
    }
}
