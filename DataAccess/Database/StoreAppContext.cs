using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Database
{
    public class StoreAppContext : DbContext
    {
        public StoreAppContext(DbContextOptions<StoreAppContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    ProductName = "Mac",
                    ProductDescription = "Apple Macbook Air M1",
                    ProductPrice = 28000,
                    CreatedOn = DateTime.Now,
                    LastModifiedOn = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CategoryID = 1
                },
                new Product()
                {
                     Id = 2,
                     ProductName = "Mac",
                     ProductDescription = "Apple Macbook Air M2",
                     ProductPrice = 32000,
                     CreatedOn = DateTime.Now,
                     LastModifiedOn = DateTime.Now,
                     IsActive = true,
                     IsDeleted = false,
                     CategoryID = 1
                });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    CategoryName = "Notebook",
                    CreatedOn = DateTime.Now,
                    LastModifiedOn = DateTime.Now,
                    IsDeleted = false,
                    IsActive = true,
                });
        }
    }
}
