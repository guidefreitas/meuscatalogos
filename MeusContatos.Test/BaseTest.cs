using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeusCatalogos.Models;
using System.Transactions;

namespace MeusCatalogos.Test
{
    [TestClass]
    public class BaseTest
    {
        [AssemblyInitialize()]
        public static void AssemblyInitialize(TestContext context)
        {
            using (var dbcontext = new MCContext())
            {
                if (dbcontext.Database.Exists())
                    dbcontext.Database.Delete();

                dbcontext.Database.CreateIfNotExists();
            }
            
            
        }

    }
}
