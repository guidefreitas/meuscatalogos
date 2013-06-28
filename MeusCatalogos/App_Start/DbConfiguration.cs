using MeusCatalogos.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace MeusCatalogos
{
    public sealed class DbConfiguration : DropCreateDatabaseIfModelChanges<MCContext>
    {
        public DbConfiguration()
        {
            // If you want automatic migrations as well uncomment below.
            // You can use both manual and automatic at the same time, but I don't recommend it.
            //AutomaticMigrationsEnabled = true;
            //AutomaticMigrationDataLossAllowed = true;
            
        }

        protected override void Seed(MCContext context)
        {
            var admin = new User
            {
                Name = "Administrator",
                Email = "admin@admin.com",
                PasswordDigest = "admin"
            };

            if (context.Users.Count(x => x.Name == admin.Name) == 0)
            {
                context.Users.Add(admin);
            }
        }

    }
}