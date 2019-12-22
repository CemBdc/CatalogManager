using CatalogManager.Data.Context;
using CatalogManager.Data.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

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

        public bool Add(T entity)
        {
            Table.Add(entity);
            return Save();
        }

        public bool Update(T entity)
        {
            Table.Update(entity);
            return Save();
        }

        public bool Delete(T entity)
        {
            Table.Remove(entity);
            return Save();
        }

        public IQueryable<T> All()
        {
            return Table;
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> where)
        {
            return Table.Where(where);
        }

        public IQueryable<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc)
        {
            if (isDesc)
                return Table.OrderByDescending(orderBy);
            return Table.OrderBy(orderBy);
        }


        private bool Save()
        {
            try
            {
                _dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
