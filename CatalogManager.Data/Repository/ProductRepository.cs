using CatalogManager.Data.Context;
using CatalogManager.Data.Models;
using CatalogManager.Data.Repository.Contracts;

namespace CatalogManager.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CatalogManagerDbContext dbContext) : base(dbContext)
        {
        }
    }
}
