namespace MeusCatalogos.Migrations
{
    using MeusCatalogos.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MeusCatalogos.Models.MCContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        private void AddFakeItemsToCatalog(MCContext context, CatalogCategory catalogCategory, User user, Company company)
        {
            for (int catalog_count = 1; catalog_count <= 15; catalog_count++)
            {
                var catalog = new Catalog
                {
                    Name = "Catalog " + catalog_count,
                    UserCreated = user,
                    Category = catalogCategory,
                    Company = company
                };
                context.Catalogs.AddOrUpdate(x => x.Name, catalog);

                for (int item_category_cout = 1; item_category_cout <= 10; item_category_cout++)
                {
                    var itemCategory = new ItemCategory { Name = "Shakes", Catalog = catalog };
                    context.ItemCategories.AddOrUpdate(x => x.Name, itemCategory);

                    for (int item_count = 1; item_count <= 10; item_count++)
                    {
                        var item = new CatalogItem { Name = "Item " + item_count, Description = "Item " + item_count + " description", Price = new Decimal(18000), Category = itemCategory };
                        context.CatalogItens.AddOrUpdate(x => x.Name, item);
                    }
                }

            }
        }

        protected override void Seed(MeusCatalogos.Models.MCContext context)
        {
            var company = new Company { Name = "DemoCompany" };
            context.Companies.AddOrUpdate(x => x.Name,company);

            var user1 =  new User
                {
                    Name = "Administrator",
                    Email = "admin@meuscatalogos.com",
                    PasswordDigest = "123"
                };

            var user2 = new User
                {
                    Name = "User",
                    Email = "user@meuscatalogos.com",
                    PasswordDigest = "123",
                    Company = context.Companies.Where(x => x.Name == "DemoCompany").FirstOrDefault()
                };

            context.Users.AddOrUpdate(x => x.Name,user1, user2);

            var catalogCategory1 = new CatalogCategory { Name = "Life and Health" };
            var catalogCategory2 = new CatalogCategory { Name = "Cars and Motorcicles" };
            var catalogCategory3 = new CatalogCategory { Name = "Jewery" };

            context.CatalogCategories.AddOrUpdate(x => x.Name, catalogCategory1, catalogCategory2, catalogCategory3 );
            context.SaveChanges();


            AddFakeItemsToCatalog(context, catalogCategory1, user2, company);
            AddFakeItemsToCatalog(context, catalogCategory2, user2, company);
            AddFakeItemsToCatalog(context, catalogCategory3, user2, company);

            var catalog1 = new Catalog
                {
                    Name = "Naturalle",
                    UserCreated = user2,
                    Category = catalogCategory1,
                    Company = company
                };

            var catalog2 = new Catalog
                {
                    Name = "MotorAwesome",
                    UserCreated = user2,
                    Category = catalogCategory2,
                    Company = company
                };

            var catalog3 = new Catalog
                {
                    Name = "RingsHeaven",
                    UserCreated = user2,
                    Category = catalogCategory3,
                    Company = company,
                    isPrivate = true
                };

            var catalog4 = new Catalog
            {
                Name = "FittMax",
                UserCreated = user2,
                Category = catalogCategory1,
                Company = company
            };

            context.Catalogs.AddOrUpdate(x => x.Name,catalog1, catalog2, catalog3);
            

            var itemCategory11 = new ItemCategory { Name = "Shakes", Catalog = catalog1 };
            var itemCategory12 = new ItemCategory { Name = "Cereal Bars", Catalog = catalog1 };
            var itemCategory13 = new ItemCategory { Name = "Supplements", Catalog = catalog1 };

            var itemCategory21 =  new ItemCategory { Name = "American Muscles", Catalog = catalog2 };
            var itemCategory22 =  new ItemCategory { Name = "Custom Bikes", Catalog = catalog2 };
            var itemCategory23 =  new ItemCategory { Name = "Racing", Catalog = catalog2 };
            
            var itemCategory31 = new ItemCategory { Name = "Engagements", Catalog = catalog3 };
            var itemCategory32 = new ItemCategory { Name = "Custom Rings", Catalog = catalog3 };
            var itemCategory33 = new ItemCategory { Name = "Diamond Rings", Catalog = catalog3 };

            var itemCategory41 = new ItemCategory { Name = "Gym Equipament", Catalog = catalog4 };
            var itemCategory42 = new ItemCategory { Name = "Gym Gear", Catalog = catalog4 };
            var itemCategory43 = new ItemCategory { Name = "Gum Clothes", Catalog = catalog4 };

            context.ItemCategories.AddOrUpdate(x => x.Name, itemCategory11, itemCategory12, itemCategory13, 
                itemCategory21, itemCategory22, itemCategory23, 
                itemCategory31, itemCategory32, itemCategory33,
                itemCategory41, itemCategory42, itemCategory43);
            

            context.CatalogItens.AddOrUpdate(x => x.Name,
                new CatalogItem { Name = "Hayabusa 1500", Description = "Hayabusa Bike", Price = new Decimal(18000), Category = itemCategory23 },
                new CatalogItem { Name = "Honda CB500", Description = "Honda CB500", Price = new Decimal(5000), Category = itemCategory23 },
                new CatalogItem { Name = "Harley Daywison", Description = "Harley", Price = new Decimal(15000), Category = itemCategory21});

            context.CatalogItens.AddOrUpdate(x => x.Name,
                new CatalogItem { Name = "Shake 1000", Description = "Low Callory Shake", Price = new Decimal(50), Category = itemCategory11 },
                new CatalogItem { Name = "Protein 2000", Description = "Protein Pounder", Price = new Decimal(3), Category = itemCategory12 },
                new CatalogItem { Name = "Whey Max", Description = "Whey Protein MAX", Price = new Decimal(200), Category = itemCategory13 });

            context.CatalogItens.AddOrUpdate(x => x.Name,
                new CatalogItem { Name = "Engagement Ring 1", Description = "Bealtiful gold engagement ring", Price = new Decimal(1000), Category = itemCategory31 },
                new CatalogItem { Name = "Debutant", Description = "White and Yellow Gold 18k", Price = new Decimal(3), Category = itemCategory32 },
                new CatalogItem { Name = "Diamond Rings", Description = "Bealtiful gold and diamond ring", Price = new Decimal(200), Category = itemCategory33 });

            context.CatalogItens.AddOrUpdate(x => x.Name,
                new CatalogItem { Name = "Weight Lifting 1", Description = "Weight", Price = new Decimal(1000), Category = itemCategory41 },
                new CatalogItem { Name = "Weight Lifting 1 Support", Description = "Support", Price = new Decimal(300), Category = itemCategory42 },
                new CatalogItem { Name = "Woman Leg", Description = "Woman Leg", Price = new Decimal(200), Category = itemCategory43 });


        }
    }
}
