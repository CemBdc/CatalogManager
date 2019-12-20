using CatalogManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogManager.Data.Context
{
    public class DBContext: DbContext
    {
        public DBContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Code = "Q1W2E3",
                    Name = "Electronics",
                    Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQuEVRd9xp1zOuFsCedkx8qZ0srywEi0Maw2vf-QdxeXNQcUUB5&s",
                    Price = 1500,
                    UpdatedAt = new DateTime()
                }
            );
        }
    }
}
