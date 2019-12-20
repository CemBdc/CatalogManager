using CatalogManager.Data.Context;
using CatalogManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CatalogManager.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DBContext dbContext) : base(dbContext)
        {
        }
    }
}
