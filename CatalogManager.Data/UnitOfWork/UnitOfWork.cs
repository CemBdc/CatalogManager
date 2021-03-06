﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CatalogManager.Data.Context;
using CatalogManager.Data.Repository;
using CatalogManager.Data.Repository.Contracts;

namespace CatalogManager.Data.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private IProductRepository _Product;
        private readonly CatalogManagerDbContext _dbContext;

        public UnitOfWork(CatalogManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IProductRepository Product
        {
            get
            {
                if (_Product == null)
                {
                    _Product = new ProductRepository(_dbContext);
                }
                return _Product;
            }
        }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public async Task<bool> CompleteAsync()
        {
            try
            {
                int _save = await _dbContext.SaveChangesAsync();
                return await Task.FromResult(true);
            }
            catch (System.Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public void Dispose() => _dbContext.Dispose();
    }
}
