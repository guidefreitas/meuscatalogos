using MeusCatalogos.Models;
using MeusCatalogos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MeusCatalogos.Controllers
{
    public partial class HomeController : Controller
    {
        //
        // GET: /Home/
        [AllowAnonymous]
        public virtual ActionResult Index()
        {
            HomeViewModel homeViewModel = new HomeViewModel();
            homeViewModel.PageTitle = "Newest Catalogs";
            
            /*
            using (var dbcontext = new MCContext())
            {
                
                if(dbcontext.Database.Exists())
                    dbcontext.Database.Delete();
                dbcontext.Database.CreateIfNotExists();

                Catalog cat1 = new Catalog();
                cat1.Name = "Catalogo 1";
                cat1.UserCreated = dbcontext.Users.Where(x => x.Name == "User").First();

                CatalogItem item1 = new CatalogItem();
                item1.Name = "Product 1";
                item1.Description = "Description 1";
                item1.Price = new Decimal(10.0);
                cat1.Itens.Add(item1);

                dbcontext.Catalogs.Add(cat1);
                dbcontext.SaveChanges();

                homeViewModel.Catalogs = dbcontext.Catalogs.Include("Itens").ToList();
                
            }
            */

            
            using (var dbcontext = new MCContext())
            {
                homeViewModel.Categories = dbcontext.CatalogCategories
                    .Include("Catalogs")
                    .Include("Catalogs.Itens")
                    .Include("Catalogs.UserCreated")
                    .Take(9)
                    .ToList();
            }
            

            return View(homeViewModel);
        }

    }
}
