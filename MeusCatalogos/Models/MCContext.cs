using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MeusCatalogos.Models
{
    public class MCContext : DbContext
    {
        public MCContext()
            : base("meuscatalogos")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<CatalogCategory> CatalogCategories { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<CatalogItem> CatalogItens { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Image> Images { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //User
            modelBuilder.Entity<User>()
                .HasKey(x => x.UserId);

            modelBuilder.Entity<User>()
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Email)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.PasswordDigest)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.Timestamp)
                .IsRowVersion();

            modelBuilder.Entity<User>()
                .Property(x => x.CreatedDateTime)
                .IsRequired();

            //Catalog
            modelBuilder.Entity<Catalog>()
               .HasKey(x => x.CatalogId);

            modelBuilder.Entity<Catalog>()
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Catalog>()
                .Property(x => x.Timestamp)
                .IsRowVersion();

            modelBuilder.Entity<Catalog>()
                .Property(x => x.CreatedDateTime)
                .IsRequired();

            /*
            modelBuilder.Entity<Catalog>()
                .HasMany(t => t.Items)
                .WithMany()
                .Map(x =>
                    {
                        x.MapLeftKey("CatalogId");
                        x.MapRightKey("ItemId");
                        x.ToTable("CatalogItems");
                    });
            */ 
                    
            //CatalogCategory
            modelBuilder.Entity<CatalogCategory>()
               .HasKey(x => x.CategoryId);

            modelBuilder.Entity<CatalogCategory>()
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<CatalogCategory>()
                .Property(x => x.Timestamp)
                .IsRowVersion();

            modelBuilder.Entity<CatalogCategory>()
                .Property(x => x.CreatedDateTime)
                .IsRequired();

            //CatalogItem
            modelBuilder.Entity<CatalogItem>()
               .HasKey(x => x.ItemId);

            modelBuilder.Entity<CatalogItem>()
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<CatalogItem>()
                .Property(x => x.Timestamp)
                .IsRowVersion();

            modelBuilder.Entity<CatalogItem>()
                .Property(x => x.CreatedDateTime)
                .IsRequired();

            //ItemCategory
            modelBuilder.Entity<ItemCategory>()
               .HasKey(x => x.CategoryId);

            modelBuilder.Entity<ItemCategory>()
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<ItemCategory>()
                .Property(x => x.Timestamp)
                .IsRowVersion();

            modelBuilder.Entity<ItemCategory>()
                .Property(x => x.CreatedDateTime)
                .IsRequired();

            //Company
            modelBuilder.Entity<Company>()
               .HasKey(x => x.CompanyId);

            modelBuilder.Entity<Company>()
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Company>()
                .Property(x => x.CreatedDateTime)
                .IsRequired();

            //Image
            modelBuilder.Entity<Image>()
               .HasKey(x => x.ImageId);

            modelBuilder.Entity<Image>()
                .Ignore(x => x.Url);
                
            modelBuilder.Entity<Image>()
                .Property(x => x.CreatedDateTime)
                .IsRequired();


            base.OnModelCreating(modelBuilder);
        }
        
    }
}