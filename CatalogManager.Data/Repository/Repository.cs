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
            try
            {
                Table.Add(entity);
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> Update(T entity)
        {
            try
            {
                Table.Update(entity);
                return await Task.FromResult(true);
            }
            catch (Exception e)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> Delete(T entity)
        {
            Table.Remove(entity);
            return await Task.FromResult(true);
        }

        public async Task<IList<T>> All()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> Get(Expression<Func<T, bool>> where)
        {
            return await Table.FirstOrDefaultAsync(where);
        }

        public async Task<IList<T>> Where(Expression<Func<T, bool>> where)
        {
            return await Table.Where(where).ToListAsync();
        }

        //public IList<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc)
        //{
        //    if (isDesc)
        //        return Table.OrderByDescending(orderBy);
        //    return Table.OrderBy(orderBy);
        //}


        //private async Task<bool> Save()
        //{
        //    try
        //    {
        //        await _dbContext.SaveChangesAsync();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
