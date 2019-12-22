using CatalogManager.Data.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManager.Data.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        Task<int> CompleteAsync();
        int Complete();
    }
}
