using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CatalogManager.Data.Repository.Contracts
{
    public interface IRepository<T> where T : class
    {
        DbSet<T> Table { get; }
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);

        Task<IList<T>> All();
        Task<IList<T>> Where(Expression<Func<T, bool>> where);
        Task<T> Get(Expression<Func<T, bool>> where);
        //IList<T> OrderBy<TKey>(Expression<Func<T, TKey>> orderBy, bool isDesc);
    }
}
