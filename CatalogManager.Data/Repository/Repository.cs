using CatalogManager.Data.Context;
using CatalogManager.Data.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CatalogManager.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly CatalogManagerDbContext _dbContext;
        public DbSet<T> Table { get; set; }

        public Repository(CatalogManagerDbContext dbContext)
        {
            this._dbContext = dbContext;
            this.Table = dbContext.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
            Table.Add(entity);
            return await Save();
        }

        public async Task<bool> Update(T entity)
        {
            Table.Update(entity);
            return await Save();
        }

        public async Task<bool> Delete(T entity)
        {
            Table.Remove(entity);
            return await Save();
        }

        public async Task<IEnumerable<T>> All()
        {
            return await Table.ToListAsync();
        }

        public async Task<bool> Get(Expression<Func<T, bool>> where)
        {
            Table.FirstOrDefaultAsync(where);
            return await Save();
        }

        public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> where)
        {
            return await Table.Where(where).ToListAsync();
        }

        public IEnumerable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc)
        {
            if (isDesc)
                return Table.OrderByDescending(orderBy);
            return Table.OrderBy(orderBy);
        }


        private async Task<bool> Save()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
