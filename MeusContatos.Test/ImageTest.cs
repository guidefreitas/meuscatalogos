using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MeusCatalogos.Models;
using System.Linq;
using System.Data.Entity.Validation;

namespace MeusCatalogos.Test
{
    [TestClass]
    public class ImageTest
    {
        public void Setup()
        {
        }

        [TestMethod]
        public void CreateImage()
        {
            using (var dbcontext = new MCContext())
            {
                try
                {
                    Image img = new Image();
                    dbcontext.Images.Add(img);
                    dbcontext.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    Assert.Fail("Tried to save invalid objects");
                }
            }
        }

        [TestMethod]
        public void DeleteImage()
        {
            using (var dbcontext = new MCContext())
            {
                try
                {
                    Image img = new Image();
                    dbcontext.Images.Add(img);
                    dbcontext.SaveChanges();

                    Image imgdb = dbcontext.Images.Where(x => x.ImageId == img.ImageId).First();
                    dbcontext.Images.Remove(imgdb);
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
